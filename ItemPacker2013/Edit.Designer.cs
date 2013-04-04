namespace ItemPacker2013
{
	partial class Edit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.itemID = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Image = global::ItemPacker2013.Properties.Resources.cross;
			this.button2.Location = new System.Drawing.Point(150, 34);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Image = global::ItemPacker2013.Properties.Resources.tick;
			this.button1.Location = new System.Drawing.Point(150, 63);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// itemID
			// 
			this.itemID.Location = new System.Drawing.Point(150, 8);
			this.itemID.Name = "itemID";
			this.itemID.Size = new System.Drawing.Size(75, 20);
			this.itemID.TabIndex = 2;
			this.itemID.Text = "-";
			// 
			// Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(233, 207);
			this.Controls.Add(this.itemID);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Edit";
			this.Padding = new System.Windows.Forms.Padding(5, 2, 5, 5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Modify";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.TextBox itemID;

	}
}