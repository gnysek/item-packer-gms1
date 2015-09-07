using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BrightIdeasSoftware;
using System.Windows.Forms;
using ItemPacker2013.Items;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ItemPacker2013
{
	public partial class MainForm : Form
	{
		public static Project CurrentProject = null;

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		public int MakeLong(short lowPart, short highPart)
		{
			return (int)(((ushort)lowPart) | (uint)(highPart << 16));
		}

		public void ListViewItem_SetSpacing(ListView listview, short leftPadding, short topPadding)
		{
			const int LVM_FIRST = 0x1000;
			const int LVM_SETICONSPACING = LVM_FIRST + 53;
			SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
		}

		public MainForm()
		{
			InitializeComponent();
			ensureButtonsVisible();
			//ListViewItem_SetSpacing(itemListView, 44, 62);
			ListViewItem_SetSpacing(itemListViewExt, 44, 62);
		}

		public void ensureButtonsVisible()
		{
			toolSave.Enabled = CurrentProject != null;
			toolOptions.Enabled = itemListViewExt.Enabled = toolAddItem.Enabled = toolSave.Enabled;
			toolImportCSV.Enabled = toolExportCSV.Enabled = toolExport.Enabled = toolSave.Enabled;
			toolFilterBox.Enabled = toolSave.Enabled;
			//toolEditItem.Enabled = (itemListViewExt.Items.Count > 0) & toolSave.Enabled & (itemListViewExt.SelectedItems.Count > 0);
			toolEditItem.Enabled = (itemListViewExt.Items.Count > 0) & toolSave.Enabled & (itemListViewExt.SelectedObjects.Count > 0);
			toolViewIcons.Enabled = (itemListViewExt.View != View.LargeIcon) & toolSave.Enabled;
			toolViewDetail.Enabled = (itemListViewExt.View != View.Details) & toolSave.Enabled;
		}

		public void closeCurrentProject()
		{

			//itemListViewExt.Items.Clear();
			//itemListViewExt.Columns.Clear();
			//itemListViewExt.Groups.Clear();
			//itemListViewExt.SetObjects(null);
			itemListViewExt.Reset();
			//itemListViewExt.Refresh();
			CurrentProject = null;
			ensureButtonsVisible();
		}

		private void toolPackage_Click(object sender, EventArgs e)
		{
			if (CurrentProject != null)
			{
				if (MessageBox.Show("Do you want to close current project? All unsaved changes will be lost!", "?", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}

			openFileDialog1.Title = "Open GMX project...";
			openFileDialog1.DefaultExt = "*.project.gmx";
			openFileDialog1.Filter = "GM:Studio Project|" + openFileDialog1.DefaultExt;
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				closeCurrentProject();
				ensureButtonsVisible();

				string fileName = "items";

				using (Prompt prompt = new Prompt())
				{
					prompt.Text = "File name";
					prompt.attrText.Text = fileName;
					prompt.ShowDialog();
					if (prompt.DialogResult == DialogResult.OK)
					{
						fileName = prompt.attrText.Text;
					}
				}

				using (SettingsForm settings = new SettingsForm())
				{
					settings.settingGMXsource.Text = openFileDialog1.FileName;
					settings.ShowDialog();
					if (settings.DialogResult == DialogResult.OK)
					{
						CurrentProject = new Project(settings.settingGMXsource.Text, fileName);
						//CurrentProject.GMXsource = settings.settingGMXsource.Text;
						//CurrentProject.preloadGMXsprites();
						////CurrentProject.GMXspritePattern = settings.settingGMXspritePattern.Text.Split('|');
						//CurrentProject.filename = Path.GetDirectoryName(CurrentProject.GMXsource) + @"\items.gear.itm";
						//CurrentProject.saveXml();
					}
				}
			}

			ensureButtonsVisible();
		}

		private void toolOpen_Click(object sender, EventArgs e)
		{
			if (CurrentProject != null)
			{
				if (MessageBox.Show("Do you want to close current project? All unsaved changes will be lost!", "?", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}

			//closeCurrentProject();

			openFileDialog1.Title = "Open Item package...";
			openFileDialog1.DefaultExt = "*.gear.itm";
			openFileDialog1.Filter = "Gear Item Package|" + openFileDialog1.DefaultExt;
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				closeCurrentProject();

				CurrentProject = new Project();
				CurrentProject.filename = openFileDialog1.FileName;

				//bool loadingResult = false;

				//while (loadingResult == false)
				while (CurrentProject.loadXml() == false)
				{
					//loadingResult = CurrentProject.loadXml();

					if (MessageBox.Show("GMX Project file not found.\n(" + CurrentProject.GMXsource + ")"
						+ "\nDo you want to manually find GM:S project used with that package?", this.Text,
						MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
					{
						closeCurrentProject();
						return;
					}

					openFileDialog1.Title = "Open GMX project...";
					openFileDialog1.DefaultExt = "*.project.gmx";
					openFileDialog1.Filter = "GM:Studio Project|" + openFileDialog1.DefaultExt;
					openFileDialog1.FileName = Path.GetFileName(CurrentProject.GMXsource);
					DialogResult gmxFindResult = openFileDialog1.ShowDialog();
					if (gmxFindResult == DialogResult.Cancel)
					{
						closeCurrentProject();
						return;
					}
					CurrentProject.GMXsource = openFileDialog1.FileName;
				}

				using (Loading form = new Loading())
				{
					//form.ShowDialog();
					form.loadSprites(new List<ImageList>() { imageListBig, imageListSmall });
				}

				if (CurrentProject.gridView == "1")
				{
					toolViewDetail_Click(sender, e);
				}
				else
				{
					toolViewIcons_Click(sender, e);
				}

				//render items
				renderItemList();
			}

			ensureButtonsVisible();
		}

		private void renderItemList()
		{
			int selection = -1;
			int count = itemListViewExt.Items.Count;
			//if (itemListViewExt.SelectedItems.Count > 0)
			if (itemListViewExt.SelectedObjects.Count > 0)
			{
				selection = itemListViewExt.SelectedIndex;
			}

			itemListViewExt.Enabled = false;
			itemListViewExt.Reset();

			// render columns
			//itemListView.Columns.Add("ID");
			//foreach (KeyValuePair<string, DefinitionData> entry in CurrentProject.attributeDefinitions)
			//{
			//    itemListView.Columns.Add(entry.Key);
			//}

			// render same for objectListView
			//List<OLVColumn> columns = new List<OLVColumn>();
			OLVColumn olvDefaultColumn = new OLVColumn() { AspectName = "ID", Text = "ID", Groupable = false, Sortable = false };
			//columns.Add(olvDefaultColumn);
			itemListViewExt.Columns.Add(olvDefaultColumn);

			foreach (KeyValuePair<string, DefinitionData> entry in CurrentProject.attributeDefinitions)
			{
				OLVColumn olvKeyCol = new OLVColumn()
				{
					Text = entry.Key,
					AspectName = entry.Key,
					//AspectGetter = delegate(object x) { return ((ItemExtendable)x).getValue(entry.Key); },
					Sortable = false,//(entry.Key != CurrentProject.GroupBy),
					Groupable = (entry.Key == CurrentProject.GroupBy),
					//IsHeaderVertical = (entry.Value.DataType == DefinitionDataType.Int),
					//,
					//FillsFreeSpace = true
				};

				if (entry.Key == CurrentProject.GroupBy)
				{
					//olvKeyCol.ImageGetter = new ImageGetterDelegate(this.RowImageGetter);
					olvDefaultColumn.ImageGetter = new ImageGetterDelegate(this.RowImageGetter);
					/*olvDefaultColumn.AspectToStringConverter = delegate(object x){
						return "eee";
					};*/
					//olvKeyCol.GroupKeyToTitleConverter = delegate(object x)
					//{
					//    return CurrentProject.groupDefinitions[CurrentProject.GroupBy].IndexOf(x.ToString()).ToString() + ". " + x.ToString();
					//};
					olvKeyCol.GroupKeyGetter = delegate(object x)
					{
						ItemExtendable item = (ItemExtendable)x;
						int eiteration = 0;
						int leadingZeros = (int)Math.Ceiling(CurrentProject.groupDefinitions[CurrentProject.GroupBy].Count / 10.0);
						string val = item.getValue(CurrentProject.GroupBy).ToString();
						foreach (string option in CurrentProject.groupDefinitions[CurrentProject.GroupBy])
						{

							if (eiteration.ToString() == val)
							{
								return (eiteration + 1).ToString().PadLeft(leadingZeros, '0') + ". " + option;
							}
							eiteration++;
						}

						return val;
					};
					// add as a first column
					//itemListViewExt.AlwaysGroupByColumn = olvKeyCol;
					olvKeyCol.Groupable = true;
					olvKeyCol.Sortable = true;
					olvKeyCol.IsVisible = false;
					itemListViewExt.PrimarySortColumn = olvKeyCol;
				}

				if (itemListViewExt.Columns.Count < 800)
				{
					itemListViewExt.Columns.Add(olvKeyCol);
					olvKeyCol.Hideable = true;
				}
			}

			itemListViewExt.ShowGroups = true;
			itemListViewExt.SetObjects(CurrentProject.itemCollection.Values.ToList());
			itemListViewExt.Visible = false;
			itemListViewExt.BuildList();

			//itemListViewExt.BuildGroups(itemListViewExt.PrimarySortColumn, SortOrder.Ascending);

			itemListViewExt.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			itemListViewExt.Visible = true;

			// render items
			//foreach (KeyValuePair<int, ItemExtendable> entry in CurrentProject.itemCollection)
			//{
			//    ListViewItem item = itemListView.Items.Add(entry.Key.ToString());
			//    item.ImageIndex = 0;
			//    item.UseItemStyleForSubItems = false;
			//    foreach (KeyValuePair<string, DefinitionData> data in CurrentProject.attributeDefinitions)
			//    {
			//        ListViewItem.ListViewSubItem c = item.SubItems.Add(entry.Value.getValueLabel(data.Key));
			//        if (data.Value.GroupName == CurrentProject.GroupBy)
			//        {
			//            item.Group = itemListView.Groups[entry.Value.getValueLabel(data.Key)];
			//        }

			//        if (data.Value.DataType == DefinitionDataType.Sprite && item.ImageIndex == 0) // 0 == not yet changed
			//        {
			//            if (imageListBig.Images.Keys.IndexOf(entry.Value.getValue(data.Key)) > -1)
			//            {
			//                item.ImageKey = entry.Value.getValue(data.Key);
			//            }
			//        }

			//        if (item.ToolTipText == "" && data.Value.DataType == DefinitionDataType.String)
			//        {
			//            item.ToolTipText = entry.Value.getValue(data.Key);
			//        }

			//        if (c.Text == CurrentProject.attributeDefinitions[data.Key].DefaultValue)
			//        {
			//            c.ForeColor = Color.Green;
			//        }
			//        else if (c.Text == "0")
			//        {
			//            c.ForeColor = Color.Gray;
			//        }
			//    }
			//}

			// auto column width
			/*foreach (ColumnHeader col in itemListView.Columns)
			{
				int w1;
				col.Width = -1;
				w1 = col.Width;
				col.Width = Math.Max(w1, 60);
			}*/

			// bring back selection
			if (selection > -1 && itemListViewExt.Items.Count == count)
			{
				itemListViewExt.SelectedIndex = selection;
				//itemListViewExt.Items[selection].Selected = true;
				itemListViewExt.Focus();
			}
			else if (itemListViewExt.Items.Count > 0)
			{
				itemListViewExt.Items[itemListViewExt.Items.Count - 1].Selected = true;
			}

			itemListViewExt.Enabled = true;
			itemListViewExt.Focus();
		}

		public object RowImageGetter(object rowObject)
		{
			ItemExtendable s = (ItemExtendable)rowObject;

			foreach (KeyValuePair<string, DefinitionData> data in CurrentProject.attributeDefinitions)
			{
				if (data.Value.DataType == DefinitionDataType.Sprite)
				{
					if (imageListSmall.Images.Keys.IndexOf(s.getValue(data.Key)) > -1)
					{
						string a = s.getValue(data.Key);
						return a;
					}
				}
			}

			return -1;
		}

		private void toolOptions_Click(object sender, EventArgs e)
		{
			if (CurrentProject == null) return;

			using (SettingsForm form = new SettingsForm())
			{
				form.settingGMXsource.Text = CurrentProject.GMXsource;
				form.settingGMXglobalItemsName.Text = CurrentProject.GMXglobalItemsName;

				form.renderTempGroupList(CurrentProject.groupDefinitions); //need to be done first
				form.renderAttributeViewList(CurrentProject.attributeDefinitions);
				form.ShowDialog();

				// reorganize everything
				if (form.DialogResult == DialogResult.OK)
				{
					DefinitionDataType type;

					// keep attribute names to remove names
					List<string> toRemove = CurrentProject.attributeDefinitions.Keys.ToList();
					List<string> toAdd = new List<string>();

					// update attribute definitions
					CurrentProject.attributeDefinitions.Clear();
					foreach (ListViewItem item in form.settingDefinitions.Items)
					{
						if (!Enum.TryParse(item.SubItems[1].Text, true, out type))
						{
							type = DefinitionDataType.String;
						}

						CurrentProject.attributeDefinitions.Add(item.SubItems[0].Text, new DefinitionData()
						{
							Export = item.Checked,
							DataType = type,
							DefaultValue = item.SubItems[3].Text,
							GroupLink = form.settingsGroupDefinitions.FindStringExact(item.SubItems[2].Text)
						});

						if (toRemove.IndexOf(item.SubItems[0].Text) > -1)
						{
							toAdd.Add(item.SubItems[0].Text);
						}

						toRemove.Remove(item.SubItems[0].Text);
					}

					// remove removed keys from items, re-set values if changed to dropdown
					if (toRemove.Count > 0)
					{
						foreach (int itemID in CurrentProject.itemCollection.Keys)
						{
							CurrentProject.itemCollection[itemID].removeKeys(toRemove);

						}
					}

					foreach (int id in CurrentProject.itemCollection.Keys)
					{
						CurrentProject.itemCollection[id].re_setValues();
					}

					// group definitions
					CurrentProject.groupDefinitions.Clear();
					foreach (KeyValuePair<string, List<string>> entry in form.tempGroups)
					{
						CurrentProject.groupDefinitions.Add(entry.Key, entry.Value);
					}

					// set group by
					CurrentProject.GroupBy = "";
					if (form.settingGroupBy.SelectedIndex > 0)
					{
						CurrentProject.GroupBy = form.settingGroupBy.Text;
					}

					renderItemList();
				}
			}
		}

		private void toolSave_Click(object sender, EventArgs e)
		{
			CurrentProject.saveXml();
		}

		private void toolEditItem_Click(object sender, EventArgs e)
		{
			if (itemListViewExt.SelectedObjects.Count > 0)
			{
				editItem(true, itemListViewExt.SelectedIndex);
			}
		}

		private void toolAddItem_Click(object sender, EventArgs e)
		{
			editItem(false, -1);
		}

		private void editItem(bool edit, int selectedID)
		{
			if (CurrentProject == null) return;

			int itemID = -1;
			if (edit)
			{
				int.TryParse(itemListViewExt.Items[selectedID].Text, out itemID);
			}

			//ListViewItem newItem = itemListView.Items.Add("Item " + itemListView.Items.Count.ToString());
			using (Edit form = new Edit())
			{
				int counter = 10;
				List<Control> controlList = new List<Control>();

				if (edit)
				{
					form.itemID.Text = itemID.ToString();
					form.EditID = itemID;
				}

				#region render_controls
				// render controls
				foreach (KeyValuePair<string, DefinitionData> definition in CurrentProject.attributeDefinitions)
				{
					Label l = new Label();
					l.Text = definition.Key + ":";
					l.Top = counter;
					l.Left = 20;
					l.Height = 13;
					form.Controls.Add(l);

					counter += 15;

					switch (definition.Value.DataType)
					{
						case DefinitionDataType.Bool:
							CheckBox c = new CheckBox();
							c.Top = counter;
							c.Left = 20;
							c.Tag = definition.Key;
							if (edit)
							{
								c.Checked = CurrentProject.itemCollection[itemID].getValue(definition.Key) == "1";
							}
							form.Controls.Add(c);
							controlList.Add(c);
							break;
						case DefinitionDataType.Int:
						case DefinitionDataType.String:

							if (definition.Value.GroupLink > -1)
							{
								ComboBox t = new ComboBox();
								t.Top = counter;
								t.Left = 20;
								t.DropDownStyle = ComboBoxStyle.DropDownList;
								t.Tag = definition.Key;

								foreach (string option in CurrentProject.groupDefinitions.ElementAt(definition.Value.GroupLink).Value)
								{
									t.Items.Add(option);
								}
								t.SelectedIndex = 0;
								if (edit)
								{
									int selected = 0;
									if (int.TryParse(CurrentProject.itemCollection[itemID].getValue(definition.Key), out selected))
									{
										t.SelectedIndex = selected;
									}
								}

								form.Controls.Add(t);
								controlList.Add(t);
							}
							else
							{
								TextBox t = new TextBox();
								t.Top = counter;
								t.Left = 20;
								t.Tag = definition.Key;
								if (edit)
								{
									t.Text = CurrentProject.itemCollection[itemID].getValue(definition.Key);
								}
								form.Controls.Add(t);
								controlList.Add(t);
							}
							break;
						case DefinitionDataType.Sprite:
							ComboBox cb = new ComboBox();
							cb.Top = counter;
							cb.Left = 20;
							cb.DropDownStyle = ComboBoxStyle.DropDownList;
							cb.Tag = definition.Key;
							foreach (string sprite in CurrentProject.GMXspritesFiltered)
							{
								cb.Items.Add(sprite);
							}
							if (edit)
							{
								cb.SelectedIndex = cb.FindStringExact(CurrentProject.itemCollection[itemID].getValue(definition.Key));
							}
							form.Controls.Add(cb);
							controlList.Add(cb);
							break;
					}

					counter += 25;
				}
				#endregion

				Label la = new Label();
				la.Text = "";
				la.Top = counter;
				la.Left = 20;
				la.Height = 13;
				form.Controls.Add(la);

				form.Height = Math.Min(500, counter + 50);

				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					ItemExtendable itemData = new ItemExtendable();

					// since it was already try-parsed in Edit form, just parse here
					itemData.ID = int.Parse(form.itemID.Text);

					if (edit)
					{
						if (itemData.ID == itemID)
						{
							itemData = CurrentProject.itemCollection[itemID];
						}
					}

					// fill data for (non-)existing item
					foreach (Control control in controlList)
					{
						switch (CurrentProject.attributeDefinitions[control.Tag.ToString()].DataType)
						{
							case DefinitionDataType.Bool:
								itemData.setValue(control.Tag.ToString(), ((CheckBox)control).Checked);
								break;
							case DefinitionDataType.Int:
								int value = 0;
								if (control is ComboBox)
								{
									value = ((ComboBox)control).SelectedIndex;
								}
								else
								{
									int.TryParse(control.Text, out value);
								}
								itemData.setValue(control.Tag.ToString(), value);
								break;
							case DefinitionDataType.Sprite:
							case DefinitionDataType.String:
								itemData.setValue(control.Tag.ToString(), control.Text);
								break;
						}
					}

					if (edit)
					{
						if (itemData.ID == itemID)
						{
							//CurrentProject.itemCollection[itemID] = itemData;
						}
						else
						{
							CurrentProject.itemCollection.Remove(itemID);
							CurrentProject.itemCollection.Add(itemData.ID, itemData);
						}
					}
					else
					{
						CurrentProject.itemCollection.Add(itemData.ID, itemData);
					}

					// render only if OK was pressed

					int selection = itemListViewExt.SelectedIndex;

					//itemListViewExt.SetObjects(CurrentProject.itemCollection.Values.ToList());
					itemListViewExt.BuildList();

					if (selection > -1)
					{
						itemListViewExt.SelectedIndex = selection;
					}
					//renderItemList();
				}
			}

			ensureButtonsVisible();
		}

		private void toolViewIcons_Click(object sender, EventArgs e)
		{
			viewChange(false);
		}

		private void toolViewDetail_Click(object sender, EventArgs e)
		{
			viewChange(true);
		}

		private void viewChange(bool details)
		{
			itemListViewExt.View = (details) ? View.Details : View.LargeIcon;
			itemListViewExt.HeaderStyle = (details) ? ColumnHeaderStyle.Clickable : ColumnHeaderStyle.None;
			ObjectListView.IgnoreMissingAspects = true;
			CurrentProject.gridView = (details) ? "1" : "0";
			ensureButtonsVisible();
		}

		private void toolExport_Click(object sender, EventArgs e)
		{
			saveFileDialog1.InitialDirectory = Path.GetDirectoryName(CurrentProject.filename);
			saveFileDialog1.Filter = "GML files|*.gml";
			saveFileDialog1.DefaultExt = "*.gml";
			//if (saveFileDialog1.FileName == "")
			//
			saveFileDialog1.FileName = "scItemDefinition.gml";
			//}

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//string filename = Path.GetDirectoryName(CurrentProject.filename) + @"\items.gml";
				CurrentProject.saveGML(saveFileDialog1.FileName);
			}
		}

		private void toolExportCSV_Click(object sender, EventArgs e)
		{
			saveFileDialog1.InitialDirectory = Path.GetDirectoryName(CurrentProject.filename);
			saveFileDialog1.Filter = "CSV files|*.csv";
			saveFileDialog1.DefaultExt = "*.csv";
			//if (saveFileDialog1.FileName == "")
			//{
			saveFileDialog1.FileName = "scItemDefinition.csv";
			//}

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//string filename = Path.GetDirectoryName(CurrentProject.filename) + @"\items.gml";
				CurrentProject.saveCSV(saveFileDialog1.FileName);
			}
		}

		private void itemListViewExt_SelectedIndexChanged(object sender, EventArgs e)
		{
			ensureButtonsVisible();
		}

		private void itemListViewExt_MouseClick(object sender, MouseEventArgs e)
		{
			ensureButtonsVisible();
		}

		private void itemListViewExt_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			toolEditItem_Click(sender, e);
		}

		private void toolImportCSV_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "CSV Files|*.csv";
			openFileDialog1.FileName = "";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				/*var lines*/
				IEnumerable<string[]> lines = File.ReadAllLines(openFileDialog1.FileName).Select(a => a.Split(','));

				List<string> duplicates = new List<string>();

				foreach (string[] line in lines)
				{
					if (line.Count() < 1) continue;
					ItemExtendable itemData = new ItemExtendable();

					int ID = 0;
					int.TryParse(line[0], out ID);
					if (CurrentProject.itemCollection.ContainsKey(ID))
					{
						ID = CurrentProject.itemCollection.Count + 1;
					}
					itemData.ID = ID;

					int i = 1;
					foreach (KeyValuePair<string, DefinitionData> entry in CurrentProject.attributeDefinitions)
					{
						if (i < line.Count())
						{
							itemData.setValue(entry.Key, line[i]);
							i++;
							continue;
						}

						itemData.setValue(entry.Key, "");
					}

					CurrentProject.itemCollection.Add(itemData.ID, itemData);
				}

				renderItemList();
			}
		}

		private void itemListViewExt_FormatCell(object sender, FormatCellEventArgs e)
		{
			if (e.ColumnIndex > 0)
			{
				if (e.CellValue.ToString() == CurrentProject.attributeDefinitions[e.Column.Text].DefaultValue)
				{
					e.SubItem.ForeColor = Color.Green;
				}

				if (e.Column.Text == "Upg")
				{
					if (e.CellValue.ToString() != "0")
					{
						e.Item.BackColor = Color.Red;
					}
				}
			}
		}

		private void toolFilterBox_TextChanged(object sender, EventArgs e)
		{
			if (itemListViewExt.Columns.Count < 4) return;

			TextMatchFilter filter = null;
			filter = TextMatchFilter.Contains(itemListViewExt, toolFilterBox.Text);

			if (filter == null)
				itemListViewExt.DefaultRenderer = null;
			else
			{
				itemListViewExt.DefaultRenderer = new HighlightTextRenderer(filter);
			}

			// Some lists have renderers already installed
			HighlightTextRenderer highlightingRenderer = itemListViewExt.GetColumn(3).Renderer as HighlightTextRenderer;
			if (highlightingRenderer != null)
				highlightingRenderer.Filter = filter;

			//Stopwatch stopWatch = new Stopwatch();
			//stopWatch.Start();
			itemListViewExt.AdditionalFilter = filter;
			//olv.Invalidate();
			//stopWatch.Stop();
		}
	}
}
