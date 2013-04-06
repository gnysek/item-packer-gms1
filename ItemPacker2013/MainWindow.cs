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

namespace ItemPacker2013
{
	public partial class MainForm : Form
	{
		public static Project CurrentProject = null;

		public MainForm()
		{
			InitializeComponent();
			ensureButtonsVisible();
		}

		public void ensureButtonsVisible()
		{
			toolSave.Enabled = CurrentProject != null;
			toolOptions.Enabled = toolSave.Enabled;
			itemListView.Enabled = toolSave.Enabled;
			toolAddItem.Enabled = toolSave.Enabled;
			toolEditItem.Enabled = (itemListView.Items.Count > 0) & toolSave.Enabled & (itemListView.SelectedItems.Count > 0);
			toolExport.Enabled = toolSave.Enabled;
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
				CurrentProject.preloadGMXsprites();
				CurrentProject.filterGMXsprites();

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
			// render columns
			itemListView.Columns.Clear();
			itemListView.Columns.Add("ID");
			foreach (KeyValuePair<string, DefinitionData> entry in CurrentProject.attributeDefinitions)
			{
				itemListView.Columns.Add(entry.Key);
			}

			// render items
			itemListView.Items.Clear();
			foreach (KeyValuePair<int, ItemExtendable> entry in CurrentProject.itemCollection)
			{
				ListViewItem item = itemListView.Items.Add(entry.Key.ToString());
				item.ImageIndex = 0;
				foreach (KeyValuePair<string, DefinitionData> data in CurrentProject.attributeDefinitions)
				{
					item.SubItems.Add(entry.Value.getValue(data.Key));
				}
			}

			// auto column width
			foreach (ColumnHeader col in itemListView.Columns)
			{
				int w1;
				col.Width = -1;
				w1 = col.Width;
				col.Width = Math.Max(w1, 60);
			}

			// bring back selection
			if (selection > -1 && itemListView.Items.Count == count)
			{
				itemListView.Items[selection].Selected = true;
			}
			else if (itemListView.Items.Count > 0)
			{
				itemListView.Items[itemListView.Items.Count - 1].Selected = true;
			}
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

					// remove removed keys from items
					if (toRemove.Count > 0)
					{
						foreach (int itemID in CurrentProject.itemCollection.Keys)
						{
							CurrentProject.itemCollection[itemID].removeKeys(toRemove);
						}
					}

					// group definitions
					CurrentProject.groupDefinitions.Clear();
					foreach (KeyValuePair<string, List<string>> entry in form.tempGroups)
					{
						CurrentProject.groupDefinitions.Add(entry.Key, entry.Value);
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

				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					ItemExtendable itemData = new ItemExtendable();
					//if (edit)
					//{
					//    itemData.ID = itemID;
					//}
					//else
					//{
					//    itemData.ID = CurrentProject.itemCollection.Count;
					//}

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
			if (saveFileDialog1.FileName == "")
			{
				saveFileDialog1.FileName = "scItemDefinition.gml";
			}

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				StreamWriter f = new StreamWriter(Path.GetDirectoryName(CurrentProject.filename) + @"\items.gml", false);

				foreach (KeyValuePair<int, ItemExtendable> item in CurrentProject.itemCollection)
				{
					int row = 0;
					string line = "";
					foreach (KeyValuePair<string, DefinitionData> definition in CurrentProject.attributeDefinitions)
					{
						switch (definition.Value.DataType)
						{
							case DefinitionDataType.Bool:
								line = item.Value.getValue(definition.Key) == "1" ? "true" : "false";
								break;
							case DefinitionDataType.Int:
								line = int.Parse(item.Value.getValue(definition.Key)).ToString();
								break;
							case DefinitionDataType.Sprite:
								line = item.Value.getValue(definition.Key);
								break;
							default:
								line = "\"" + item.Value.getValue(definition.Key) + "\"";
								break;
						}

						f.WriteLine(CurrentProject.GMXglobalItemsName + "[" + item.Key.ToString() + "," + (row++) + "] = " + line + ";");
					}
				}

				f.Close();
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
	}
}
