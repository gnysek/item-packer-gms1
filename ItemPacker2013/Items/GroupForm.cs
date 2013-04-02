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
	public partial class GroupForm : Form
	{
		public GroupForm()
		{
			InitializeComponent();
		}

		private void GroupForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				if (groupOptions.Items.Count < 1)
				{
					MessageBox.Show("You need to add at least one item");
					e.Cancel = true;
				}
			}
		}

		private void attrAddB_Click(object sender, EventArgs e)
		{
			using (Prompt form = new Prompt())
			{
				form.attrText.Text = "New Option " + groupOptions.Items.Count.ToString();
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					if (groupOptions.FindStringExact(form.attrText.Text) > -1)
					{
						MessageBox.Show("Duplicate of key " + form.attrText.Text);
						return;
					}

					groupOptions.Items.Add(form.attrText.Text);
					groupOptions.SelectedIndex = groupOptions.Items.Count - 1;
				}
			}
		}

		private void attrEditB_Click(object sender, EventArgs e)
		{
			int editPos = groupOptions.SelectedIndex;

			if (editPos > -1)
			{
				using (Prompt form = new Prompt())
				{
					form.attrText.Text = groupOptions.Items[editPos].ToString();
					form.ShowDialog();

					if (form.DialogResult == DialogResult.OK)
					{
						int duplicateId = groupOptions.FindStringExact(form.attrText.Text);
						if ( duplicateId > -1 && duplicateId != editPos)
						{
							MessageBox.Show("Duplicate of key " + form.attrText.Text);
							return;
						}

						groupOptions.Items[editPos] = form.attrText.Text;
						groupOptions.SelectedIndex = editPos;
					}
				}
			}
		}

		private void attrDeleteB_Click(object sender, EventArgs e)
		{
			int editPos = groupOptions.SelectedIndex;

			if (editPos > -1)
			{
				groupOptions.Items.RemoveAt(editPos);
			}
		}

		private void moveItem(int index, bool up)
		{
			if (index < 0) return;
			if (up && index == 0) return;
			if (!up && index == groupOptions.Items.Count - 1) return;

			object temp = groupOptions.Items[index];

			groupOptions.Items.RemoveAt(index);

			if (up)
			{
				groupOptions.Items.Insert(index - 1, temp);
				groupOptions.SelectedIndex = index - 1;
			}
			else
			{
				groupOptions.Items.Insert(index + 1, temp);
				groupOptions.SelectedIndex = index + 1;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			moveItem(groupOptions.SelectedIndex, true);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			moveItem(groupOptions.SelectedIndex, false);
		}
	}
}
