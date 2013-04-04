using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ItemPacker2013
{
	public partial class Edit : Form
	{
		public int EditID = -1;

		public Edit()
		{
			InitializeComponent();
		}

		private void Edit_FormClosing(object sender, FormClosingEventArgs e)
		{
			int tmpID = -1;
			int.TryParse(itemID.Text, out tmpID);

			Regex match = new Regex("^[0-9]+$");

			if (tmpID == -1 || !match.IsMatch(itemID.Text))
			{
				itemID.BackColor = Color.Red;
				e.Cancel = true;
				return;
			}

			if (MainForm.CurrentProject.itemCollection.ContainsKey(tmpID) && EditID != tmpID)
			{
				itemID.BackColor = Color.Red;
				e.Cancel = true;
				MessageBox.Show("There is already item with that ID");
				return;
			}
		}
	}
}
