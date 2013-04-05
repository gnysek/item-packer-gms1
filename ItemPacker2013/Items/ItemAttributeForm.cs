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
			bool isSprite = (settingType.Items[settingType.SelectedIndex].ToString() == ItemDefinitionType.Sprite.ToString());
			settingDefault.Enabled = settingDropdown.Enabled = !isSprite;
			settingSpriteDropdown.Visible = isSprite;
			settingDefault.Visible = !isSprite;
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
				if (settingType.Text == ItemDefinitionType.Sprite.ToString())
				{
					attrData.DefaultValue = settingSpriteDropdown.Text;
				}
				attrData.GroupLink = settingDropdown.SelectedIndex - 1;
			}
		}

		private void ItemAttributeForm_Load(object sender, EventArgs e)
		{
			// add value types
			foreach (ItemDefinitionType definition in Enum.GetValues(typeof(ItemDefinitionType)))
			{
				settingType.Items.Add(definition.ToString());
				if (definition.ToString() == attrData.Type.ToString())
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
			if (attrData.Type == ItemDefinitionType.Sprite)
			{
				int sel = settingSpriteDropdown.FindStringExact( attrData.DefaultValue );
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
	}
}
