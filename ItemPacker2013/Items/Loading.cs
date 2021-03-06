﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ItemPacker2013.Items
{
	public partial class Loading : Form
	{
		public Loading()
		{
			InitializeComponent();
		}

		public void loadSprites(List<ImageList> imgs)
		{
			Show();

			foreach (ImageList imgl in imgs)
			{
				if (imgl.Images.Count > 1)
				{
					for (int i = 1; i < imgl.Images.Count; i++)
					{
						imgl.Images.RemoveAt(i);
					}
				}
			}

			progressBar.Value = 0;
			progressBar.Maximum = MainForm.CurrentProject.GMXspritesFiltered.Count;

			string fdir = Path.GetDirectoryName(MainForm.CurrentProject.GMXsource) + @"\sprites\images\";
			foreach (string sprName in MainForm.CurrentProject.GMXspritesFiltered)
			{
				foreach (ImageList imgl in imgs)
				{
					imgl.Images.Add(sprName, new Bitmap(fdir + sprName + "_0.png"));
				}
				progressBar.Value++;
			}

			Close();
		}
	}
}
