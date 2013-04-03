using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ItemPacker2013.Items;

namespace ItemPacker2013
{
	public partial class SettingsForm : Form
	{
		public int editItemIndex = -1;
		public int editGroupIndex = -1;
		public Dictionary<string, List<string>> tempGroups = new Dictionary<string, List<string>>();

		public SettingsForm()
		{
			InitializeComponent();
		}

		private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool cancel = false;

			settingGMXsource.BackColor = SystemColors.Window;
			if (!File.Exists(settingGMXsource.Text))
			{
				cancel = true;
				settingGMXsource.BackColor = Color.Red;
			}

			e.Cancel = cancel;
		}

		public bool renderAttributeViewList(Dictionary<string, DefinitionData> definitions)
		{
			settingDefinitions.Items.Clear();
			foreach (KeyValuePair<string, DefinitionData> definition in definitions)
			{
				addAttributeViewList(definition);
			}
			return true;
		}

		public bool renderTempGroupList(Dictionary<string, List<string>> definitions)
		{
			settingsGroupDefinitions.Items.Clear();
			tempGroups.Clear();
			foreach (KeyValuePair<string, List<string>> entry in definitions)
			{
				settingsGroupDefinitions.Items.Add(entry.Key);
				tempGroups.Add(entry.Key, entry.Value);
			}
			return true;
		}

		#region attributes list adding/addB/editB/deleteB

		private bool addAttributeViewList(KeyValuePair<string, DefinitionData> entry)
		{
			ListViewItem item = settingDefinitions.Items.Add(entry.Key);
			item.SubItems.Add(entry.Value.Type.ToString());
			item.SubItems.Add((entry.Value.GroupLink == -1) ? "-" : entry.Value.GroupLink.ToString());
			item.SubItems.Add(entry.Value.DefaultValue);
			return true;
		}

		private bool addAttributeViewList(string name, DefinitionData data)
		{
			return addAttributeViewList(new KeyValuePair<string, DefinitionData>(name, data));
		}

		private void renderAttributeDropdownGroupList(ItemAttributeForm form)
		{
			form.settingDropdown.Items.Clear();
			form.settingDropdown.Items.Add("- Disabled -");
			foreach (KeyValuePair<string, List<string>> element in tempGroups)
			{
				form.settingDropdown.Items.Add(element.Key);
			}
		}

		private void attrAddB_Click(object sender, EventArgs e)
		{
			using (ItemAttributeForm form = new ItemAttributeForm())
			{
				renderAttributeDropdownGroupList(form);
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					if (settingDefinitions.FindItemWithText(form.attrName) != null)
					{
						MessageBox.Show("Duplicated Key: " + form.attrName);
						return;
					}

					addAttributeViewList(form.attrName, form.attrData);
				}
			}
		}

		private void attrEditB_Click(object sender, EventArgs e)
		{
			if (settingDefinitions.SelectedItems.Count > 0)
			{
				editItemIndex = settingDefinitions.SelectedItems[0].Index;

				using (ItemAttributeForm form = new ItemAttributeForm())
				{
					form.attrName = settingDefinitions.SelectedItems[0].Text;
					form.attrData.TypeString = settingDefinitions.SelectedItems[0].SubItems[1].Text;
					form.attrData.GroupLink = settingsGroupDefinitions.FindStringExact(settingDefinitions.SelectedItems[0].SubItems[2].Text) + 1;
					form.attrData.DefaultValue = settingDefinitions.SelectedItems[0].SubItems[3].Text;
					form.bOK.Text = "Update";
					form.bOK.Image = new Bitmap(ItemPacker2013.Properties.Resources.pencil);
					renderAttributeDropdownGroupList(form);
					//form.settingDropdown.SelectedItem = form.attrData.GroupLink;
					//form.settingDropdown.SelectedValue = form.attrData.GroupLink;

					form.ShowDialog();

					if (form.DialogResult == DialogResult.OK)
					{
						if (settingDefinitions.FindItemWithText(form.attrName) != null)
						{
							//if new Name isn't same as this item previous Name, that means above conflict is with another element
							if (form.attrName != settingDefinitions.Items[editItemIndex].Text)
							{
								MessageBox.Show("Duplicated Key: " + form.attrName);
								return;
							}
						}

						settingDefinitions.Items[editItemIndex].Text = form.attrName;
						settingDefinitions.Items[editItemIndex].SubItems[1].Text = form.attrData.TypeString;
						settingDefinitions.Items[editItemIndex].SubItems[2].Text = (form.attrData.GroupLink == -1) ? "-" : settingsGroupDefinitions.Items[form.attrData.GroupLink].ToString();
						settingDefinitions.Items[editItemIndex].SubItems[3].Text = form.attrData.DefaultValue;
					}
				}
			}
			editItemIndex = -1;
		}

		private void attrDeleteB_Click(object sender, EventArgs e)
		{
			if (settingDefinitions.SelectedItems.Count > 0)
			{
				if (settingDefinitions.Items.Count == 1)
				{
					MessageBox.Show("At least one item must stay on that list");
					return;
				}

				settingDefinitions.Items.RemoveAt(settingDefinitions.SelectedItems[0].Index);
			}
		}

		#endregion

		private void groupAddB_Click(object sender, EventArgs e)
		{
			using (GroupForm form = new GroupForm())
			{
				form.groupName.Text = "New Group";
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					if (settingsGroupDefinitions.FindStringExact(form.groupName.Text) > -1)
					{
						MessageBox.Show("Duplicate for key: " + form.groupName.Text);
						return;
					}

					tempGroups.Add(form.groupName.Text, form.groupOptions.Items.Cast<string>().ToList());
					settingsGroupDefinitions.Items.Add(form.groupName.Text);
				}
			}
		}

		private void groupEditB_Click(object sender, EventArgs e)
		{
			editGroupIndex = settingsGroupDefinitions.SelectedIndex;

			if (editGroupIndex < 0)
			{
				return;
			}

			string editGroupLabel = settingsGroupDefinitions.Items[editGroupIndex].ToString();

			using (GroupForm form = new GroupForm())
			{
				form.groupName.Text = editGroupLabel;
				foreach (string option in tempGroups[editGroupLabel])
				{
					form.groupOptions.Items.Add(option);
				}
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					int duplicateLocation = settingsGroupDefinitions.FindStringExact(form.groupName.Text);
					if (duplicateLocation > -1 && duplicateLocation != editGroupIndex)
					{
						MessageBox.Show("Duplicate for key: " + form.groupName.Text);
						editGroupIndex = -1;
						return;
					}

					if (duplicateLocation > -1)
					{
						// name is same
						tempGroups[editGroupLabel] = form.groupOptions.Items.Cast<string>().ToList();
					}
					else
					{
						tempGroups.Remove(editGroupLabel);
						editGroupLabel = form.groupName.Text;
						tempGroups.Add(editGroupLabel, form.groupOptions.Items.Cast<string>().ToList());
						settingsGroupDefinitions.Items[editGroupIndex] = editGroupLabel;
					}
				}
			}

			editGroupIndex = -1;
		}

	}
}
