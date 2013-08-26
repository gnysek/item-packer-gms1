using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ItemPacker2013.Items;
using System.IO;
using System.Runtime.InteropServices;
using BrightIdeasSoftware;

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
			ListViewItem_SetSpacing(itemListView, 44, 62);
		}

		public void ensureButtonsVisible()
		{
			toolSave.Enabled = CurrentProject != null;
			toolOptions.Enabled = toolSave.Enabled;
			itemListView.Enabled = toolSave.Enabled;
			toolAddItem.Enabled = toolSave.Enabled;
			toolEditItem.Enabled = (itemListView.Items.Count > 0) & toolSave.Enabled & (itemListView.SelectedItems.Count > 0);
			toolImportCSV.Enabled = toolExportCSV.Enabled = toolExport.Enabled = toolSave.Enabled;
			toolViewIcons.Enabled = (itemListView.View != View.LargeIcon) & toolSave.Enabled;
			toolViewDetail.Enabled = (itemListView.View != View.Details) & toolSave.Enabled;
		}

		public void closeCurrentProject()
		{
			CurrentProject = null;
			itemListView.Items.Clear();
			itemListView.Columns.Clear();
			itemListView.Groups.Clear();
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

			CurrentProject = null;
			ensureButtonsVisible();

			openFileDialog1.Title = "Open GMX project...";
			openFileDialog1.DefaultExt = "*.project.gmx";
			openFileDialog1.Filter = "GM:Studio Project|" + openFileDialog1.DefaultExt;
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				using (SettingsForm settings = new SettingsForm())
				{
					settings.settingGMXsource.Text = openFileDialog1.FileName;
					settings.ShowDialog();
					if (settings.DialogResult == DialogResult.OK)
					{
						CurrentProject = new Project();
						CurrentProject.GMXsource = settings.settingGMXsource.Text;
						CurrentProject.preloadGMXsprites();
						//CurrentProject.GMXspritePattern = settings.settingGMXspritePattern.Text.Split('|');
						CurrentProject.filename = Path.GetDirectoryName(CurrentProject.GMXsource) + @"\items.gear.itm";
						CurrentProject.saveXml();
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

			closeCurrentProject();

			openFileDialog1.Title = "Open Item package...";
			openFileDialog1.DefaultExt = "*.gear.itm";
			openFileDialog1.Filter = "Gear Item Package|" + openFileDialog1.DefaultExt;
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				CurrentProject = new Project();
				CurrentProject.filename = openFileDialog1.FileName;
				CurrentProject.loadXml();

				using (Loading form = new Loading())
				{
					//form.ShowDialog();
					form.loadSprites(new List<ImageList>() { imageList1, imageList2 });
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
			int count = itemListView.Items.Count;
			if (itemListView.SelectedItems.Count > 0)
			{
				selection = itemListView.SelectedItems[0].Index;
			}

			itemListView.Enabled = false;
			itemListView.Items.Clear();
			itemListView.Columns.Clear();
			itemListView.Groups.Clear();
			objectListView1.Columns.Clear();

			// render columns
			itemListView.Columns.Add("ID");
			foreach (KeyValuePair<string, DefinitionData> entry in CurrentProject.attributeDefinitions)
			{
				itemListView.Columns.Add(entry.Key);
			}

			// render same for objectListView
			List<OLVColumn> columns = new List<OLVColumn>();
			OLVColumn olvDefaultColumn = new OLVColumn() { AspectName = "ID", Text = "ID", Groupable = false, Sortable = true };
			olvDefaultColumn.ImageGetter = new ImageGetterDelegate(this.RowImageGetter);
			columns.Add(olvDefaultColumn);
			//objectListView1.Columns.Add(olvDefaultColumn);

			foreach (KeyValuePair<string, DefinitionData> entry in CurrentProject.attributeDefinitions)
			{
				OLVColumn olvKeyCol = new OLVColumn() { Text = entry.Key, AspectName = entry.Key, Sortable = (entry.Key == CurrentProject.GroupBy), Groupable = (entry.Key == CurrentProject.GroupBy) };

				if (entry.Key == CurrentProject.GroupBy)
				{
					objectListView1.Columns.Add(olvKeyCol);
				}
				else
				{
					columns.Add(olvKeyCol);
				}
			}

			objectListView1.Columns.AddRange(columns.ToArray());

			// render groups
			itemListView.ShowGroups = false;
			int iteration = 0;
			if (CurrentProject.GroupBy.Length > 0)
			{
				foreach (string option in CurrentProject.groupDefinitions[CurrentProject.GroupBy])
				{
					iteration++;
					itemListView.Groups.Add(option, iteration.ToString() + ". " + option);
				}
				itemListView.ShowGroups = true;
			}

			objectListView1.SetObjects(CurrentProject.itemCollection.Values.ToList());

			// render items
			foreach (KeyValuePair<int, ItemExtendable> entry in CurrentProject.itemCollection)
			{
				ListViewItem item = itemListView.Items.Add(entry.Key.ToString());
				item.ImageIndex = 0;
				item.UseItemStyleForSubItems = false;
				foreach (KeyValuePair<string, DefinitionData> data in CurrentProject.attributeDefinitions)
				{
					ListViewItem.ListViewSubItem c = item.SubItems.Add(entry.Value.getValueLabel(data.Key));
					if (data.Value.GroupName == CurrentProject.GroupBy)
					{
						item.Group = itemListView.Groups[entry.Value.getValueLabel(data.Key)];
					}

					if (data.Value.DataType == DefinitionDataType.Sprite && item.ImageIndex == 0) // 0 == not yet changed
					{
						if (imageList1.Images.Keys.IndexOf(entry.Value.getValue(data.Key)) > -1)
						{
							item.ImageKey = entry.Value.getValue(data.Key);
						}
					}

					if (item.ToolTipText == "" && data.Value.DataType == DefinitionDataType.String)
					{
						item.ToolTipText = entry.Value.getValue(data.Key);
					}

					if (c.Text == CurrentProject.attributeDefinitions[data.Key].DefaultValue)
					{
						c.ForeColor = Color.Green;
					}
					else if (c.Text == "0")
					{
						c.ForeColor = Color.Gray;
					}
				}
			}

			// auto column width
			/*foreach (ColumnHeader col in itemListView.Columns)
			{
				int w1;
				col.Width = -1;
				w1 = col.Width;
				col.Width = Math.Max(w1, 60);
			}*/

			// bring back selection
			if (selection > -1 && itemListView.Items.Count == count)
			{
				itemListView.Items[selection].Selected = true;
			}
			else if (itemListView.Items.Count > 0)
			{
				itemListView.Items[itemListView.Items.Count - 1].Selected = true;
			}

			itemListView.Enabled = true;
		}

		public object RowImageGetter(object rowObject)
		{
			ItemExtendable s = (ItemExtendable)rowObject;

			foreach (KeyValuePair<string, DefinitionData> data in CurrentProject.attributeDefinitions)
			{
				if (data.Value.DataType == DefinitionDataType.Sprite)
				{
					if (imageList2.Images.Keys.IndexOf(s.getValue(data.Key)) > -1)
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
			if (itemListView.SelectedItems.Count > 0)
			{
				editItem(true, itemListView.SelectedItems[0].Index);
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
				int.TryParse(itemListView.Items[selectedID].Text, out itemID);
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

				form.Height = Math.Min(500, counter + 50);

				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					ItemExtendable itemData = new ItemExtendable();

					// since it was already try-parsed in Edit form, just parse here
					itemData.ID = int.Parse(form.itemID.Text);

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
							CurrentProject.itemCollection[itemID] = itemData;
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
					renderItemList();
				}
			}

			ensureButtonsVisible();
		}

		private void toolViewIcons_Click(object sender, EventArgs e)
		{
			itemListView.View = View.LargeIcon;
			CurrentProject.gridView = "0";
			ensureButtonsVisible();
		}

		private void toolViewDetail_Click(object sender, EventArgs e)
		{
			itemListView.View = View.Details;
			CurrentProject.gridView = "1";
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

		private void itemListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			ensureButtonsVisible();
		}

		private void itemListView_MouseClick(object sender, MouseEventArgs e)
		{
			ensureButtonsVisible();
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

		private void itemListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			toolEditItem_Click(sender, e);
		}
	}
}
