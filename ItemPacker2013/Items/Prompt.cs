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
	public partial class Prompt : Form
	{
		public Prompt()
		{
			InitializeComponent();
		}

		private void Prompt_FormClosing(object sender, FormClosingEventArgs e)
		{
			attrText.BackColor = SystemColors.Window;
			if (attrText.Text.Length == 0)
			{
				attrText.BackColor = Color.Red;
				e.Cancel = true;
			}
		}
	}
}
