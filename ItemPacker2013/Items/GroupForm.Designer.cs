namespace ItemPacker2013.Items
{
	partial class GroupForm
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
			this.groupName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupOptions = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.attrAddB = new System.Windows.Forms.Button();
			this.attrEditB = new System.Windows.Forms.Button();
			this.attrDeleteB = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// groupName
			// 
			this.groupName.Location = new System.Drawing.Point(12, 25);
			this.groupName.Name = "groupName";
			this.groupName.Size = new System.Drawing.Size(205, 20);
			this.groupName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Group Name:";
			// 
			// groupOptions
			// 
			this.groupOptions.FormattingEnabled = true;
			this.groupOptions.Location = new System.Drawing.Point(12, 64);
			this.groupOptions.Name = "groupOptions";
			this.groupOptions.Size = new System.Drawing.Size(205, 147);
			this.groupOptions.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Options:";
			// 
			// button3
			// 
			this.button3.Image = global::ItemPacker2013.Properties.Resources.arrow_up;
			this.button3.Location = new System.Drawing.Point(12, 217);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(24, 24);
			this.button3.TabIndex = 20;
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// attrAddB
			// 
			this.attrAddB.Image = global::ItemPacker2013.Properties.Resources.add;
			this.attrAddB.Location = new System.Drawing.Point(133, 217);
			this.attrAddB.Name = "attrAddB";
			this.attrAddB.Size = new System.Drawing.Size(24, 24);
			this.attrAddB.TabIndex = 19;
			this.attrAddB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.attrAddB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.attrAddB.UseVisualStyleBackColor = true;
			this.attrAddB.Click += new System.EventHandler(this.attrAddB_Click);
			// 
			// attrEditB
			// 
			this.attrEditB.Image = global::ItemPacker2013.Properties.Resources.pencil;
			this.attrEditB.Location = new System.Drawing.Point(163, 217);
			this.attrEditB.Name = "attrEditB";
			this.attrEditB.Size = new System.Drawing.Size(24, 24);
			this.attrEditB.TabIndex = 18;
			this.attrEditB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.attrEditB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.attrEditB.UseVisualStyleBackColor = true;
			this.attrEditB.Click += new System.EventHandler(this.attrEditB_Click);
			// 
			// attrDeleteB
			// 
			this.attrDeleteB.Enabled = false;
			this.attrDeleteB.Image = global::ItemPacker2013.Properties.Resources.delete;
			this.attrDeleteB.Location = new System.Drawing.Point(193, 217);
			this.attrDeleteB.Name = "attrDeleteB";
			this.attrDeleteB.Size = new System.Drawing.Size(24, 24);
			this.attrDeleteB.TabIndex = 17;
			this.attrDeleteB.UseVisualStyleBackColor = true;
			this.attrDeleteB.Click += new System.EventHandler(this.attrDeleteB_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button2.Image = global::ItemPacker2013.Properties.Resources.tick;
			this.button2.Location = new System.Drawing.Point(163, 247);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(54, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "OK";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Image = global::ItemPacker2013.Properties.Resources.cross;
			this.button1.Location = new System.Drawing.Point(87, 247);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(70, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Cancel";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Image = global::ItemPacker2013.Properties.Resources.arrow_down;
			this.button4.Location = new System.Drawing.Point(42, 217);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(24, 24);
			this.button4.TabIndex = 21;
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// GroupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(230, 284);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.attrAddB);
			this.Controls.Add(this.attrEditB);
			this.Controls.Add(this.attrDeleteB);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupOptions);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "GroupForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GroupForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.TextBox groupName;
		public System.Windows.Forms.ListBox groupOptions;
		private System.Windows.Forms.Button attrAddB;
		private System.Windows.Forms.Button attrEditB;
		private System.Windows.Forms.Button attrDeleteB;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}