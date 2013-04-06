using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ItemPacker2013.Items
{
	public partial class ItemAttributeForm : Form
	{
		public string attrName = "Add new Attribute";
		public DefinitionData attrData = new DefinitionData();
		//public KeyValuePair<string, DefinitionData> currentAttribute;

		public ItemAttributeForm()
		{
			InitializeComponent();
		}

		private void checkIsSprite()
		{
			bool isSprite = (settingType.Items[settingType.SelectedIndex].ToString() == DefinitionDataType.Sprite.ToString());

			int index = settingDropdown.SelectedIndex - 1;

			if (index > -1 && !isSprite)
			{
				settingDropdownOptionDefault.Items.Clear();
				foreach (string option in MainForm.CurrentProject.groupDefinitions.ElementAt(index).Value)
				{
					settingDropdownOptionDefault.Items.Add(option);
				}

				if (attrData.DefaultValue.Length > 0)
				{
					if (attrData.DataType == DefinitionDataType.String)
					{
						settingDropdownOptionDefault.SelectedIndex = Math.Max(0, settingDropdownOptionDefault.FindStringExact(attrData.DefaultValue));
					}
					else
					{
						int selected = 0;
						int.TryParse(attrData.DefaultValue, out selected);
						settingDropdownOptionDefault.SelectedIndex = Math.Max(0, selected);
					}
				}
			}

			// set visibility
			// settingDefault.Enabled =
			settingDropdown.Enabled = !isSprite;
			settingSpriteDropdown.Visible = isSprite;
			settingDefault.Visible = !isSprite & index < 0;
			settingDropdownOptionDefault.Visible = !isSprite & index > -1;
		}

		private void ItemAttributeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				settingName.BackColor = SystemColors.Window;
				if (settingName.Text.Length == 0)
				{
					settingName.BackColor = Color.Red;
					e.Cancel = true;
				}

				attrName = settingName.Text;
				attrData.TypeString = settingType.Text;
				attrData.DefaultValue = settingDefault.Text;
				if (settingType.Text == DefinitionDataType.Sprite.ToString())
				{
					attrData.DefaultValue = settingSpriteDropdown.Text;
				}

				if (settingDropdownOptionDefault.Visible)
				{
					switch (attrData.DataType)
					{
						case DefinitionDataType.Bool:
							attrData.DefaultValue = Math.Min(1, settingDropdownOptionDefault.SelectedIndex).ToString();
							break;
						case DefinitionDataType.Int:
							attrData.DefaultValue = settingDropdownOptionDefault.SelectedIndex.ToString();
							break;
						default:
							attrData.DefaultValue = settingDropdownOptionDefault.Text;
							break;
					}
				}
				attrData.GroupLink = settingDropdown.SelectedIndex - 1;
			}
		}

		private void ItemAttributeForm_Load(object sender, EventArgs e)
		{
			// add value types
			foreach (DefinitionDataType definition in Enum.GetValues(typeof(DefinitionDataType)))
			{
				settingType.Items.Add(definition.ToString());
				if (definition.ToString() == attrData.DataType.ToString())
				{
					settingType.SelectedIndex = settingType.Items.Count - 1;
				}
			}

			// add sprites
			foreach (string sprite in MainForm.CurrentProject.GMXspritesFiltered)
			{
				settingSpriteDropdown.Items.Add(sprite);
			}


			settingSpriteDropdown.SelectedIndex = 0;
			if (attrData.DataType == DefinitionDataType.Sprite)
			{
				int sel = settingSpriteDropdown.FindStringExact(attrData.DefaultValue);
				if (sel > -1)
				{
					settingSpriteDropdown.SelectedIndex = sel;
				}
			}

			// set group link
			if (attrData.GroupLink > -1)
			{
				settingDropdown.SelectedIndex = attrData.GroupLink;
			}
			else
			{
				settingDropdown.SelectedIndex = 0;
			}

			settingName.Text = attrName;
			settingDefault.Text = attrData.DefaultValue;

			checkIsSprite();
		}

		private void settingType_SelectedIndexChanged(object sender, EventArgs e)
		{
			checkIsSprite();
		}

		private void settingDropdown_SelectedIndexChanged(object sender, EventArgs e)
		{
			checkIsSprite();
		}
	}
}
