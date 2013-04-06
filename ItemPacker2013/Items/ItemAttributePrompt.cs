using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ItemPacker2013.Items
{
	class ItemAttributePrompt
	{
		public static KeyValuePair<string, DefinitionDataType> ShowDialog(string Caption, string AttrName, DefinitionDataType AttrType)
		{
			DefinitionDataType type;

			Form prompt = new Form();
			prompt.Width = 350;
			prompt.Height = 107;
			prompt.Text = Caption;
			prompt.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			prompt.StartPosition = FormStartPosition.CenterParent;
			prompt.ControlBox = false;
			prompt.ShowInTaskbar = false;

			Label textLabel = new Label() { Left = 12, Top = 9, Height = 13, Text = "Attribute data:" };
			TextBox textBox = new TextBox() { Left = 12, Top = 25, Text = AttrName, Width = 150 };
			ComboBox dropDown = new ComboBox() { Left = 182, Top = 25, Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
			Button confirmation = new Button() { Text = "OK", Left = 276, Width = 56, Top = 50, DialogResult = DialogResult.OK };
			confirmation.Font = new Font(confirmation.Font, FontStyle.Bold);
			confirmation.Image = new Bitmap(ItemPacker2013.Properties.Resources.tick);
			confirmation.TextImageRelation = TextImageRelation.ImageBeforeText;
			confirmation.TextAlign = ContentAlignment.MiddleRight;

			Button cancel = new Button { Text = "Cancel", Left = 190, Width = 75, Top = 50, DialogResult = DialogResult.Cancel };
			cancel.Image = new Bitmap(ItemPacker2013.Properties.Resources.cross);
			cancel.TextImageRelation = TextImageRelation.ImageBeforeText;
			cancel.TextAlign = ContentAlignment.MiddleRight;

			foreach (DefinitionDataType definition in Enum.GetValues(typeof(DefinitionDataType)))
			{
				dropDown.Items.Add(definition.ToString());
				if (AttrType == definition)
				{
					dropDown.SelectedIndex = dropDown.Items.Count - 1;
				}
			}

			confirmation.Click += (sender, e) => {prompt.Close();};
			cancel.Click += (sender, e) => { textBox.Text = ""; };
			prompt.Controls.Add(textLabel);
			prompt.Controls.Add(textBox);
			prompt.Controls.Add(dropDown);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(cancel);
			prompt.ShowDialog();

			
			if (!Enum.TryParse(dropDown.Text, true, out type))
			{
				type = DefinitionDataType.String;
			}

			return new KeyValuePair<string, DefinitionDataType>(textBox.Text, type);
		}
	}
}
