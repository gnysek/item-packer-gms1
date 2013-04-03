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
		public Project CurrentProject = null;

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
			toolEditItem.Enabled = (itemListView.Items.Count > 0) & toolSave.Enabled;
			toolExport.Enabled = toolSave.Enabled;
			toolViewIcons.Enabled = (itemListView.View != View.LargeIcon) & toolSave.Enabled;
			toolViewDetail.Enabled = (itemListView.View != View.Details) & toolSave.Enabled;
		}

		public void closeCurrentProject()
		{
			CurrentProject = null;
			itemListView.Items.Clear();
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

				itemListView.Columns.Clear();
				itemListView.Columns.Add("ID");
				foreach (KeyValuePair<string, DefinitionData> entry in CurrentProject.attributeDefinitions)
				{
					itemListView.Columns.Add(entry.Key);
				}

				foreach (KeyValuePair<int, ItemExtendable> entry in CurrentProject.itemCollection)
				{
					ListViewItem item = itemListView.Items.Add(entry.Key.ToString());
					foreach (KeyValuePair<string, DefinitionData> data in CurrentProject.attributeDefinitions)
					{
						item.SubItems.Add(entry.Value.getValue(data.Key));
					}
				}
			}

			ensureButtonsVisible();
			if (CurrentProject.gridView == "1")
			{
				toolViewDetail_Click(sender, e);
			}
			else
			{
				toolViewIcons_Click(sender, e);
			}
		}

		private void toolOptions_Click(object sender, EventArgs e)
		{
			if (CurrentProject == null) return;

			using (SettingsForm form = new SettingsForm())
			{
				form.settingGMXsource.Text = CurrentProject.GMXsource;
				form.settingGMXglobalItemsName.Text = CurrentProject.GMXglobalItemsName;

				form.renderAttributeViewList(CurrentProject.attributeDefinitions);
				form.renderTempGroupList(CurrentProject.groupDefinitions);
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					CurrentProject.attributeDefinitions.Clear();
					ItemDefinitionType type;

					foreach (ListViewItem item in form.settingDefinitions.Items)
					{
						if (!Enum.TryParse(item.SubItems[1].Text, true, out type))
						{
							type = ItemDefinitionType.String;
						}
						CurrentProject.attributeDefinitions.Add(item.SubItems[0].Text, new DefinitionData() { Type = type });
					}

					CurrentProject.groupDefinitions.Clear();

					foreach (KeyValuePair<string, List<string>> entry in form.tempGroups)
					{
						CurrentProject.groupDefinitions.Add(entry.Key, entry.Value);
					}

					//foreach(string item in form.settingsGroupDefinitions.Items) {
					//    CurrentProject.groupDefinitions.Add(item, new List<string>());
					//}
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

				foreach (KeyValuePair<string, DefinitionData> definition in CurrentProject.attributeDefinitions)
				{
					Label l = new Label();
					l.Text = definition.Key + ":";
					l.Top = counter;
					l.Left = 20;
					l.Height = 13;
					form.Controls.Add(l);

					counter += 15;

					switch (definition.Value.Type)
					{
						case ItemDefinitionType.Bool:
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
						case ItemDefinitionType.Int:
						case ItemDefinitionType.String:
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
							break;
						//case ItemDefinitionType.Dropdown:
						case ItemDefinitionType.Sprite:
							ComboBox cb = new ComboBox();
							cb.Top = counter;
							cb.Left = 20;
							cb.DropDownStyle = ComboBoxStyle.DropDownList;
							cb.Tag = definition.Key;
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

				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					ItemExtendable itemData = new ItemExtendable();
					if (edit)
					{
						itemData.ID = itemID;
					}
					else
					{
						itemData.ID = CurrentProject.itemCollection.Count;
					}

					ListViewItem newItem;

					if (edit)
					{
						newItem = itemListView.Items[selectedID];
						if (newItem != null)
						{
							//newItem.SubItems[0].Text = selectedID.ToString();
							newItem.SubItems.Clear();
							newItem.Text = selectedID.ToString();
						}
					}
					else
					{
						newItem = itemListView.Items.Add(itemData.ID.ToString());
					}

					foreach (Control control in controlList)
					{
						//MessageBox.Show(control.Tag.ToString());
						switch (CurrentProject.attributeDefinitions[control.Tag.ToString()].Type)
						{
							case ItemDefinitionType.Bool:
								itemData.setValue(control.Tag.ToString(), ((CheckBox)control).Checked);
								newItem.SubItems.Add(((CheckBox)control).Checked ? "Y" : "-");
								break;
							case ItemDefinitionType.Int:
								int value = 0;
								int.TryParse(control.Text, out value);
								itemData.setValue(control.Tag.ToString(), value);
								newItem.SubItems.Add(value.ToString());
								break;
							case ItemDefinitionType.Sprite:
							case ItemDefinitionType.String:
								itemData.setValue(control.Tag.ToString(), control.Text);
								newItem.SubItems.Add(control.Text);
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
						switch (definition.Value.Type)
						{
							case ItemDefinitionType.Bool:
								line = item.Value.getValue(definition.Key) == "1" ? "true" : "false";
								break;
							case ItemDefinitionType.Int:
								line = int.Parse(item.Value.getValue(definition.Key)).ToString();
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
	}
}
