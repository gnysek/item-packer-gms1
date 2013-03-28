﻿using System;
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
			}
		}

		private void ItemAttributeForm_Load(object sender, EventArgs e)
		{
			foreach (ItemDefinitionType definition in Enum.GetValues(typeof(ItemDefinitionType)))
			{
				settingType.Items.Add(definition.ToString());
				if (definition.ToString() == attrData.Type.ToString())
				{
					settingType.SelectedIndex = settingType.Items.Count - 1;
				}
			}

			settingDropdown.SelectedIndex = 0;
			settingName.Text = attrName;
			settingDefault.Text = attrData.DefaultValue;
		}
	}
}
