using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ItemPacker2013.Items;
using System.IO;

namespace ItemPacker2013
{
	public partial class MainForm : Form
	{
		public Project CurrentProject = null;

		public MainForm()
		{
			InitializeComponent();
			ensureButtonsVisible();
		}

		public void ensureButtonsVisible()
		{
			toolSave.Enabled = CurrentProject != null;
			toolOptions.Enabled = toolSave.Enabled;
			itemListView.Enabled = toolSave.Enabled;
		}

		private void toolPackage_Click(object sender, EventArgs e)
		{
			if (CurrentProject != null)
			{
				if (MessageBox.Show("Do you want to close current project? All unsaved changes will be lost!", "?", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}

			CurrentProject = null;
			ensureButtonsVisible();

			openFileDialog1.Title = "Open GMX project...";
			openFileDialog1.DefaultExt = "*.project.gmx";
			openFileDialog1.Filter = "GM:Studio Project|" + openFileDialog1.DefaultExt;
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				using (SettingsForm settings = new SettingsForm())
				{
					settings.settingGMXsource.Text = openFileDialog1.FileName;
					settings.ShowDialog();
					if (settings.DialogResult == DialogResult.OK)
					{
						CurrentProject = new Project();
						CurrentProject.GMXsource = settings.settingGMXsource.Text;
						//CurrentProject.GMXspritePattern = settings.settingGMXspritePattern.Text.Split('|');
						CurrentProject.filename = Path.GetDirectoryName(CurrentProject.GMXsource) + @"\items.gear.itm";
						CurrentProject.saveXml();
					}
				}
			}

			ensureButtonsVisible();
		}

		private void toolOpen_Click(object sender, EventArgs e)
		{
			if (CurrentProject != null)
			{
				if (MessageBox.Show("Do you want to close current project? All unsaved changes will be lost!", "?", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}

			CurrentProject = null;
			ensureButtonsVisible();

			openFileDialog1.Title = "Open Item package...";
			openFileDialog1.DefaultExt = "*.gear.itm";
			openFileDialog1.Filter = "Gear Item Package|" + openFileDialog1.DefaultExt;
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				CurrentProject = new Project();
				CurrentProject.filename = openFileDialog1.FileName;
				CurrentProject.loadXml();
			}

			ensureButtonsVisible();
		}

		private void toolOptions_Click(object sender, EventArgs e)
		{
			if (CurrentProject == null) return;

			using (SettingsForm form = new SettingsForm())
			{
				form.settingGMXsource.Text = CurrentProject.GMXsource;
				form.settingGMXglobalItemsName.Text = CurrentProject.GMXglobalItemsName;

				form.renderAttributeViewList(CurrentProject.attributeDefinitions);
				form.ShowDialog();

				if (form.DialogResult == DialogResult.OK)
				{
					CurrentProject.attributeDefinitions.Clear();
					ItemDefinitionType type;

					foreach (ListViewItem item in form.settingDefinitions.Items)
					{
						if (!Enum.TryParse(item.SubItems[1].Text, true, out type))
						{
							type = ItemDefinitionType.String;
						}
						CurrentProject.attributeDefinitions.Add(item.SubItems[0].Text, new DefinitionData() { Type = type });
					}
				}
			}
		}

		private void toolSave_Click(object sender, EventArgs e)
		{
			CurrentProject.saveXml();
		}
	}
}
