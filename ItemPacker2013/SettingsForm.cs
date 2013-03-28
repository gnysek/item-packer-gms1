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

		private bool addAttributeViewList(KeyValuePair<string, DefinitionData> entry)
		{
			ListViewItem item = settingDefinitions.Items.Add(entry.Key);
			item.SubItems.Add(entry.Value.Type.ToString());
			item.SubItems.Add((entry.Value.GroupLink == -1) ? "-" : entry.Value.GroupLink.ToString());
			return true;
		}

		private bool addAttributeViewList(string name, DefinitionData data)
		{
			return addAttributeViewList(new KeyValuePair<string, DefinitionData>(name, data));
		}

		private void attrAddB_Click(object sender, EventArgs e)
		{
			using (ItemAttributeForm form = new ItemAttributeForm())
			{
				KeyValuePair<string, DefinitionData> entry = new KeyValuePair<string, DefinitionData>("Add new Attribute",new DefinitionData());

				form.currentAttribute = entry;
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					if (settingDefinitions.FindItemWithText(form.currentAttribute.Key) != null)
					{
						MessageBox.Show("Duplicated Key: " + form.settingName.Text);
						return;
					}

					addAttributeViewList(form.currentAttribute);
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
					KeyValuePair<string, DefinitionData> entry = new KeyValuePair<string, DefinitionData>(settingDefinitions.SelectedItems[0].Text, new DefinitionData()
					{
						TypeString = settingDefinitions.SelectedItems[0].SubItems[1].Text
					});

					form.currentAttribute = entry;
					form.ShowDialog();

					if (form.DialogResult == DialogResult.OK)
					{
						if (settingDefinitions.FindItemWithText(entry.Key) != null)
						{
							//if new Name isn't same as this item previous Name, that means above conflict is with another element
							if (form.currentAttribute.Key != settingDefinitions.Items[editItemIndex].Text)
							{
								MessageBox.Show("Duplicated Key: " + form.currentAttribute.Key);
								return;
							}
						}

						settingDefinitions.Items[editItemIndex].Text = form.currentAttribute.Key;
						settingDefinitions.Items[editItemIndex].SubItems[1].Text = form.currentAttribute.Value.TypeString;
					}
				}

				//ItemDefinitionType type;
				//if (!Enum.TryParse(settingDefinitions.SelectedItems[0].SubItems[1].Text, true, out type))
				//{
				//    type = ItemDefinitionType.String;
				//}

				//KeyValuePair<string, ItemDefinitionType> t = ItemAttributePrompt.ShowDialog("Edit attribute", settingDefinitions.SelectedItems[0].Text, type);
				//if (t.Key != "")
				//{
				//    // if found existing item with same Name
				//    if (settingDefinitions.FindItemWithText(t.Key) != null)
				//    {
				//        //if new Name isn't same as this item previous Name, that means above conflict is with another element
				//        if (t.Key != settingDefinitions.Items[editItemIndex].Text)
				//        {
				//            MessageBox.Show("Duplicated Key: " + t.Key);
				//            return;
				//        }
				//    }

				//    settingDefinitions.Items[editItemIndex].Text = t.Key;
				//    settingDefinitions.Items[editItemIndex].SubItems[1].Text = t.Value.ToString();
				//}
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

	}
}
