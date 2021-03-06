﻿using System;
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
		//public int editItemIndex = -1;
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
				_addAttributeViewList(definition);
			}
			return true;
		}

		public bool renderTempGroupList(Dictionary<string, List<string>> definitions)
		{
			settingsGroupDefinitions.Items.Clear();
			tempGroups.Clear();
			settingGroupBy.Items.Clear();
			settingGroupBy.Items.Add("- None -");
			foreach (KeyValuePair<string, List<string>> entry in definitions)
			{
				settingsGroupDefinitions.Items.Add(entry.Key);
				tempGroups.Add(entry.Key, entry.Value);
				settingGroupBy.Items.Add(entry.Key);
			}
			settingGroupBy.SelectedIndex = Math.Max(0, settingGroupBy.FindStringExact(MainForm.CurrentProject.GroupBy));
			return true;
		}

		#region attributes list adding/addB/editB/deleteB

		// button ADD
		private void attrAddB_Click(object sender, EventArgs e)
		{
			_attributeEdit(false);
		}

		// button EDIT
		private void attrEditB_Click(object sender, EventArgs e)
		{
			if (settingDefinitions.SelectedItems.Count > 0)
			{
				_attributeEdit(true);
			}
		}

		// button DELETE
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

		private void _addAttributeViewList(string name, DefinitionData data)
		{
			_addAttributeViewList(new KeyValuePair<string, DefinitionData>(name, data));
		}

		private void _addAttributeViewList(KeyValuePair<string, DefinitionData> entry)
		{
			ListViewItem item = settingDefinitions.Items.Add(entry.Key);
			_updateAttributeViewList(item, entry);
		}

		private void _updateAttributeViewList(ListViewItem item, KeyValuePair<string, DefinitionData> entry)
		{
			_updateAttributeViewList(
				item,
				entry.Value.Export,
				entry.Key,
				entry.Value.DataType.ToString(),
				(entry.Value.GroupLink == -1) ? "-" : settingsGroupDefinitions.Items[entry.Value.GroupLink].ToString(),
				entry.Value.DefaultValue
			);
		}

		private void _updateAttributeViewList(ListViewItem item, bool export, string name, string type, string dropdown, string defVal)
		{
			ListViewItem.ListViewSubItem sub;
			item.SubItems.Clear();
			item.Text = name;
			item.Checked = export;
			item.UseItemStyleForSubItems = false;
			sub = item.SubItems.Add(type);
			switch (type)
			{
				case "String":
					sub.BackColor = Color.LightGray;
					break;
				case "Int":
					sub.BackColor = Color.LightSteelBlue;
					break;
				case "Bool":
					sub.BackColor = Color.LightCyan;
					break;
				case "Sprite":
					sub.BackColor = Color.LightGoldenrodYellow;
					break;
			}
			item.SubItems.Add(dropdown);
			item.SubItems.Add(defVal);
		}

		private void _attributeEdit(bool edit)
		{
			int editItemIndex = -1;
			if (edit)
			{
				editItemIndex = settingDefinitions.SelectedItems[0].Index;
			}

			using (ItemAttributeForm form = new ItemAttributeForm())
			{
				if (edit)
				{
					form.attrName = settingDefinitions.SelectedItems[0].Text;
					form.attrData.TypeString = settingDefinitions.SelectedItems[0].SubItems[1].Text;
					form.attrData.GroupLink = settingsGroupDefinitions.FindStringExact(settingDefinitions.SelectedItems[0].SubItems[2].Text) + 1;
					form.attrData.DefaultValue = settingDefinitions.SelectedItems[0].SubItems[3].Text;
					form.bOK.Text = "Update";
					form.bOK.Image = new Bitmap(ItemPacker2013.Properties.Resources.pencil);
				}

				renderAttributeDropdownGroupList(form);
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					if (settingDefinitions.FindItemWithText(form.attrName) != null)
					{
						if (edit)
						{
							//if new Name isn't same as this item previous Name, that means above conflict is with another element
							if (form.attrName != settingDefinitions.Items[editItemIndex].Text)
							{
								MessageBox.Show("Duplicated Key: " + form.attrName);
								return;
							}
						}
						else
						{
							MessageBox.Show("Duplicated Key: " + form.attrName);
							return;
						}
					}

					if (edit)
					{
						_updateAttributeViewList(settingDefinitions.Items[editItemIndex], new KeyValuePair<string, DefinitionData>(form.attrName, form.attrData));
					}
					else
					{
						_addAttributeViewList(form.attrName, form.attrData);
					}
				}
			}
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
					settingGroupBy.Items.Add(form.groupName.Text);
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
						settingGroupBy.Items.Remove(editGroupLabel);
						editGroupLabel = form.groupName.Text;
						tempGroups.Add(editGroupLabel, form.groupOptions.Items.Cast<string>().ToList());
						settingsGroupDefinitions.Items[editGroupIndex] = editGroupLabel;
						settingGroupBy.Items.Add(form.groupName.Text);
					}
				}
			}

			editGroupIndex = -1;
		}

		private void settingGMXglobalItemsName_TextChanged(object sender, EventArgs e)
		{
			changeRadioValues();
		}

		private void changeRadioValues()
		{
			radioButton1.Text = settingGMXglobalItemsName.Text + "[ID, Attr] =";
			radioButton2.Text = settingGMXglobalItemsName.Text + "Attr[ID] =";
		}

		private void move(bool up)
		{
			if (settingDefinitions.SelectedItems.Count > 0)
			{
				if (up && settingDefinitions.SelectedItems[0].Index == 0) return;
				if (!up && settingDefinitions.SelectedItems[0].Index == settingDefinitions.Items.Count - 1) return;

				int index = settingDefinitions.SelectedItems[0].Index;
				ListViewItem toMove = settingDefinitions.Items[index];
				settingDefinitions.Items.RemoveAt(index);
				settingDefinitions.Items.Insert((up) ? index - 1 : index + 1, toMove);
			}
		}

		private void attrUpB_Click(object sender, EventArgs e)
		{
			move(true);
		}

		private void attrDownB_Click(object sender, EventArgs e)
		{
			move(false);
		}

	}
}
