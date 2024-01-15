namespace Lab4b
{
    partial class BraedensFileCheckerApp
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.formMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exitFile = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkTagsProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.checkTagListBox = new System.Windows.Forms.ListBox();
            this.formMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(24, 47);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(116, 20);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "No File Loaded";
            // 
            // formMenu
            // 
            this.formMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem});
            this.formMenu.Location = new System.Drawing.Point(0, 0);
            this.formMenu.Name = "formMenu";
            this.formMenu.Size = new System.Drawing.Size(378, 24);
            this.formMenu.TabIndex = 2;
            this.formMenu.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFile,
            this.exitFile});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFile
            // 
            this.loadFile.Name = "loadFile";
            this.loadFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadFile.Size = new System.Drawing.Size(173, 22);
            this.loadFile.Tag = "";
            this.loadFile.Text = "Load File ...";
            this.loadFile.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // exitFile
            // 
            this.exitFile.Name = "exitFile";
            this.exitFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitFile.Size = new System.Drawing.Size(173, 22);
            this.exitFile.Text = "Exit";
            this.exitFile.Click += new System.EventHandler(this.exitFile_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkTagsProcess});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // checkTagsProcess
            // 
            this.checkTagsProcess.Name = "checkTagsProcess";
            this.checkTagsProcess.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.checkTagsProcess.Size = new System.Drawing.Size(175, 22);
            this.checkTagsProcess.Text = "Check Tags";
            this.checkTagsProcess.Click += new System.EventHandler(this.checkTagsProcess_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "ofd";
            // 
            // checkTagListBox
            // 
            this.checkTagListBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTagListBox.FormattingEnabled = true;
            this.checkTagListBox.ItemHeight = 18;
            this.checkTagListBox.Location = new System.Drawing.Point(12, 82);
            this.checkTagListBox.Name = "checkTagListBox";
            this.checkTagListBox.Size = new System.Drawing.Size(354, 328);
            this.checkTagListBox.TabIndex = 4;
            this.checkTagListBox.TabStop = false;
            this.checkTagListBox.Tag = "";
            // 
            // BraedensFileCheckerApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 432);
            this.Controls.Add(this.checkTagListBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.formMenu);
            this.MainMenuStrip = this.formMenu;
            this.Name = "BraedensFileCheckerApp";
            this.Text = "Braeden\'s File Checker App";
            this.formMenu.ResumeLayout(false);
            this.formMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.MenuStrip formMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFile;
        private System.Windows.Forms.ToolStripMenuItem exitFile;
        private System.Windows.Forms.ToolStripMenuItem checkTagsProcess;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ListBox checkTagListBox;
    }
}

