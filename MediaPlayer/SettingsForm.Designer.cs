namespace MediaPlayer
{
    partial class SettingsForm
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
            this.checkBoxSavePathToFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxRepeatCircle = new System.Windows.Forms.CheckBox();
            this.checkBoxRollUpTray = new System.Windows.Forms.CheckBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.BlackLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxSavePathToFolder
            // 
            this.checkBoxSavePathToFolder.AutoSize = true;
            this.checkBoxSavePathToFolder.Location = new System.Drawing.Point(13, 37);
            this.checkBoxSavePathToFolder.Name = "checkBoxSavePathToFolder";
            this.checkBoxSavePathToFolder.Size = new System.Drawing.Size(116, 17);
            this.checkBoxSavePathToFolder.TabIndex = 0;
            this.checkBoxSavePathToFolder.Text = "Save path to folder";
            this.checkBoxSavePathToFolder.UseVisualStyleBackColor = true;
            this.checkBoxSavePathToFolder.CheckedChanged += new System.EventHandler(this.checkBoxSavePathToFolder_CheckedChanged);
            // 
            // checkBoxRepeatCircle
            // 
            this.checkBoxRepeatCircle.AutoSize = true;
            this.checkBoxRepeatCircle.Location = new System.Drawing.Point(13, 61);
            this.checkBoxRepeatCircle.Name = "checkBoxRepeatCircle";
            this.checkBoxRepeatCircle.Size = new System.Drawing.Size(103, 17);
            this.checkBoxRepeatCircle.TabIndex = 1;
            this.checkBoxRepeatCircle.Text = "Repeat by circle";
            this.checkBoxRepeatCircle.UseVisualStyleBackColor = true;
            this.checkBoxRepeatCircle.CheckedChanged += new System.EventHandler(this.checkBoxRepeatCircle_CheckedChanged);
            // 
            // checkBoxRollUpTray
            // 
            this.checkBoxRollUpTray.AutoSize = true;
            this.checkBoxRollUpTray.Location = new System.Drawing.Point(13, 85);
            this.checkBoxRollUpTray.Name = "checkBoxRollUpTray";
            this.checkBoxRollUpTray.Size = new System.Drawing.Size(90, 17);
            this.checkBoxRollUpTray.TabIndex = 2;
            this.checkBoxRollUpTray.Text = "Roll up in tray";
            this.checkBoxRollUpTray.UseVisualStyleBackColor = true;
            this.checkBoxRollUpTray.CheckedChanged += new System.EventHandler(this.checkBoxRollUpTray_CheckedChanged);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.BlackLabel);
            this.MainPanel.Controls.Add(this.checkBoxRollUpTray);
            this.MainPanel.Controls.Add(this.checkBoxRepeatCircle);
            this.MainPanel.Controls.Add(this.checkBoxSavePathToFolder);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(234, 411);
            this.MainPanel.TabIndex = 0;
            // 
            // BlackLabel
            // 
            this.BlackLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BlackLabel.Location = new System.Drawing.Point(0, 406);
            this.BlackLabel.Name = "BlackLabel";
            this.BlackLabel.Size = new System.Drawing.Size(231, 5);
            this.BlackLabel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(230, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 411);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 411);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 5);
            this.label3.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 411);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSavePathToFolder;
        private System.Windows.Forms.CheckBox checkBoxRepeatCircle;
        private System.Windows.Forms.CheckBox checkBoxRollUpTray;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BlackLabel;
    }
}