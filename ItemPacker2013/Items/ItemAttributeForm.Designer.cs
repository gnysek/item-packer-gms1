namespace ItemPacker2013.Items
{
	partial class ItemAttributeForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.settingName = new System.Windows.Forms.TextBox();
			this.settingType = new System.Windows.Forms.ComboBox();
			this.settingDropdown = new System.Windows.Forms.ComboBox();
			this.butCancel = new System.Windows.Forms.Button();
			this.bOK = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.settingDefault = new System.Windows.Forms.TextBox();
			this.settingSpriteDropdown = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Attribute name:";
			// 
			// settingName
			// 
			this.settingName.Location = new System.Drawing.Point(12, 25);
			this.settingName.Name = "settingName";
			this.settingName.Size = new System.Drawing.Size(200, 20);
			this.settingName.TabIndex = 0;
			// 
			// settingType
			// 
			this.settingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.settingType.FormattingEnabled = true;
			this.settingType.Location = new System.Drawing.Point(218, 25);
			this.settingType.Name = "settingType";
			this.settingType.Size = new System.Drawing.Size(100, 21);
			this.settingType.TabIndex = 1;
			this.settingType.SelectedIndexChanged += new System.EventHandler(this.settingType_SelectedIndexChanged);
			// 
			// settingDropdown
			// 
			this.settingDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.settingDropdown.Items.AddRange(new object[] {
            "Disabled"});
			this.settingDropdown.Location = new System.Drawing.Point(218, 68);
			this.settingDropdown.Name = "settingDropdown";
			this.settingDropdown.Size = new System.Drawing.Size(100, 21);
			this.settingDropdown.TabIndex = 3;
			// 
			// butCancel
			// 
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Image = global::ItemPacker2013.Properties.Resources.cross;
			this.butCancel.Location = new System.Drawing.Point(162, 95);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75, 23);
			this.butCancel.TabIndex = 4;
			this.butCancel.Text = "Cancel";
			this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.butCancel.UseVisualStyleBackColor = true;
			// 
			// bOK
			// 
			this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bOK.Image = global::ItemPacker2013.Properties.Resources.add;
			this.bOK.Location = new System.Drawing.Point(243, 95);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(75, 23);
			this.bOK.TabIndex = 5;
			this.bOK.Text = "Add";
			this.bOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.bOK.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(215, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Type:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(215, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Dropdown:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(146, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Default value (can be empty):";
			// 
			// settingDefault
			// 
			this.settingDefault.Location = new System.Drawing.Point(12, 68);
			this.settingDefault.Name = "settingDefault";
			this.settingDefault.Size = new System.Drawing.Size(200, 20);
			this.settingDefault.TabIndex = 2;
			// 
			// settingSpriteDropdown
			// 
			this.settingSpriteDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.settingSpriteDropdown.Location = new System.Drawing.Point(12, 68);
			this.settingSpriteDropdown.Name = "settingSpriteDropdown";
			this.settingSpriteDropdown.Size = new System.Drawing.Size(146, 21);
			this.settingSpriteDropdown.TabIndex = 9;
			this.settingSpriteDropdown.Visible = false;
			// 
			// ItemAttributeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(328, 130);
			this.Controls.Add(this.settingSpriteDropdown);
			this.Controls.Add(this.settingDefault);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.settingDropdown);
			this.Controls.Add(this.settingType);
			this.Controls.Add(this.settingName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "ItemAttributeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ItemAttributeForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemAttributeForm_FormClosing);
			this.Load += new System.EventHandler(this.ItemAttributeForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox settingName;
		public System.Windows.Forms.ComboBox settingType;
		public System.Windows.Forms.ComboBox settingDropdown;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox settingDefault;
		public System.Windows.Forms.Button bOK;
		public System.Windows.Forms.ComboBox settingSpriteDropdown;
	}
}