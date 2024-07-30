namespace NoitaSaveManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxManualPath;
        private System.Windows.Forms.Button buttonSavePath;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonRestoreSave;
        private System.Windows.Forms.ComboBox comboBoxFolderList;
        private System.Windows.Forms.Button buttonConfirmRestore;
        private System.Windows.Forms.PictureBox pictureBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            textBoxManualPath = new System.Windows.Forms.TextBox();
            buttonSavePath = new System.Windows.Forms.Button();
            buttonContinue = new System.Windows.Forms.Button();
            buttonRestoreSave = new System.Windows.Forms.Button();
            comboBoxFolderList = new System.Windows.Forms.ComboBox();
            buttonConfirmRestore = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(226, 23);
            button1.TabIndex = 0;
            button1.Text = "Automatically find Noita save location";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(button1_Click);
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(400, 23);
            textBox1.TabIndex = 1;
            // 
            // textBoxManualPath
            // 
            textBoxManualPath.Location = new System.Drawing.Point(12, 67);
            textBoxManualPath.Name = "textBoxManualPath";
            textBoxManualPath.Size = new System.Drawing.Size(400, 23);
            textBoxManualPath.TabIndex = 2;
            textBoxManualPath.Visible = false;
            // 
            // buttonSavePath
            // 
            buttonSavePath.Location = new System.Drawing.Point(418, 67);
            buttonSavePath.Name = "buttonSavePath";
            buttonSavePath.Size = new System.Drawing.Size(75, 23);
            buttonSavePath.TabIndex = 3;
            buttonSavePath.Text = "Save Path";
            buttonSavePath.UseVisualStyleBackColor = true;
            buttonSavePath.Click += new System.EventHandler(buttonSavePath_Click);
            // 
            // buttonContinue
            // 
            buttonContinue.Location = new System.Drawing.Point(12, 93);
            buttonContinue.Name = "buttonContinue";
            buttonContinue.Size = new System.Drawing.Size(200, 23);
            buttonContinue.TabIndex = 4;
            buttonContinue.Text = "Save current run";
            buttonContinue.UseVisualStyleBackColor = true;
            buttonContinue.Visible = false;
            buttonContinue.Click += new System.EventHandler(buttonContinue_Click);
            // 
            // buttonRestoreSave
            // 
            buttonRestoreSave.Location = new System.Drawing.Point(12, 122);
            buttonRestoreSave.Name = "buttonRestoreSave";
            buttonRestoreSave.Size = new System.Drawing.Size(200, 23);
            buttonRestoreSave.TabIndex = 5;
            buttonRestoreSave.Text = "Restore Save";
            buttonRestoreSave.UseVisualStyleBackColor = true;
            buttonRestoreSave.Visible = false;
            buttonRestoreSave.Click += new System.EventHandler(buttonRestoreSave_Click);
            // 
            // comboBoxFolderList
            // 
            comboBoxFolderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxFolderList.FormattingEnabled = true;
            comboBoxFolderList.Location = new System.Drawing.Point(12, 151);
            comboBoxFolderList.Name = "comboBoxFolderList";
            comboBoxFolderList.Size = new System.Drawing.Size(400, 23);
            comboBoxFolderList.TabIndex = 6;
            comboBoxFolderList.Visible = false;
            // 
            // buttonConfirmRestore
            // 
            buttonConfirmRestore.Location = new System.Drawing.Point(271, 122);
            buttonConfirmRestore.Name = "buttonConfirmRestore";
            buttonConfirmRestore.Size = new System.Drawing.Size(141, 23);
            buttonConfirmRestore.TabIndex = 8;
            buttonConfirmRestore.Text = "Confirm Restore";
            buttonConfirmRestore.UseVisualStyleBackColor = true;
            buttonConfirmRestore.Click += new System.EventHandler(buttonConfirmRestore_Click);
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.Location = new System.Drawing.Point(12, 180);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(480, 163);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(504, 355);
            Controls.Add(pictureBox1);
            Controls.Add(buttonConfirmRestore);
            Controls.Add(comboBoxFolderList);
            Controls.Add(buttonRestoreSave);
            Controls.Add(buttonContinue);
            Controls.Add(buttonSavePath);
            Controls.Add(textBoxManualPath);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Noita Save Manager";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
