namespace DirMerger
{
    partial class Form2
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
            this.codeViewer = new System.Windows.Forms.RichTextBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.textZoomMenuTab = new System.Windows.Forms.ToolStripMenuItem();
            this.textZoomOption1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textZoomOption2 = new System.Windows.Forms.ToolStripMenuItem();
            this.textZoomOption3 = new System.Windows.Forms.ToolStripMenuItem();
            this.textZoomOption4 = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuTab = new System.Windows.Forms.ToolStripMenuItem();
            this.editingOption = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeViewer
            // 
            this.codeViewer.Location = new System.Drawing.Point(12, 27);
            this.codeViewer.Name = "codeViewer";
            this.codeViewer.ReadOnly = true;
            this.codeViewer.Size = new System.Drawing.Size(560, 722);
            this.codeViewer.TabIndex = 0;
            this.codeViewer.Text = "";
            this.codeViewer.WordWrap = false;
            this.codeViewer.ZoomFactor = 2F;
            this.codeViewer.TextChanged += new System.EventHandler(this.CodeViewer_TextChanged);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenuTab,
            this.textZoomMenuTab});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(584, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // textZoomMenuTab
            // 
            this.textZoomMenuTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textZoomOption1,
            this.textZoomOption2,
            this.textZoomOption3,
            this.textZoomOption4});
            this.textZoomMenuTab.Name = "textZoomMenuTab";
            this.textZoomMenuTab.Size = new System.Drawing.Size(75, 20);
            this.textZoomMenuTab.Text = "Text Zoom";
            // 
            // textZoomOption1
            // 
            this.textZoomOption1.Name = "textZoomOption1";
            this.textZoomOption1.Size = new System.Drawing.Size(180, 22);
            this.textZoomOption1.Text = "0.5x";
            this.textZoomOption1.Click += new System.EventHandler(this.TextZoomOption_Click);
            // 
            // textZoomOption2
            // 
            this.textZoomOption2.Name = "textZoomOption2";
            this.textZoomOption2.Size = new System.Drawing.Size(180, 22);
            this.textZoomOption2.Text = "1x";
            this.textZoomOption2.Click += new System.EventHandler(this.TextZoomOption_Click);
            // 
            // textZoomOption3
            // 
            this.textZoomOption3.Name = "textZoomOption3";
            this.textZoomOption3.Size = new System.Drawing.Size(180, 22);
            this.textZoomOption3.Text = "1.5x";
            this.textZoomOption3.Click += new System.EventHandler(this.TextZoomOption_Click);
            // 
            // textZoomOption4
            // 
            this.textZoomOption4.Name = "textZoomOption4";
            this.textZoomOption4.Size = new System.Drawing.Size(180, 22);
            this.textZoomOption4.Text = "2x";
            this.textZoomOption4.Click += new System.EventHandler(this.TextZoomOption_Click);
            // 
            // editMenuTab
            // 
            this.editMenuTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editingOption,
            this.saveOption});
            this.editMenuTab.Name = "editMenuTab";
            this.editMenuTab.Size = new System.Drawing.Size(39, 20);
            this.editMenuTab.Text = "Edit";
            // 
            // editingOption
            // 
            this.editingOption.Name = "editingOption";
            this.editingOption.Size = new System.Drawing.Size(180, 22);
            this.editingOption.Text = "Start Editing";
            this.editingOption.Click += new System.EventHandler(this.EditingOption_Click);
            // 
            // saveOption
            // 
            this.saveOption.Name = "saveOption";
            this.saveOption.Size = new System.Drawing.Size(180, 22);
            this.saveOption.Text = "Save";
            this.saveOption.Click += new System.EventHandler(this.SaveOption_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 761);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.codeViewer);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Form2";
            this.Text = "Code Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeViewer;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem textZoomMenuTab;
        private System.Windows.Forms.ToolStripMenuItem textZoomOption1;
        private System.Windows.Forms.ToolStripMenuItem textZoomOption2;
        private System.Windows.Forms.ToolStripMenuItem textZoomOption3;
        private System.Windows.Forms.ToolStripMenuItem textZoomOption4;
        private System.Windows.Forms.ToolStripMenuItem editMenuTab;
        private System.Windows.Forms.ToolStripMenuItem editingOption;
        private System.Windows.Forms.ToolStripMenuItem saveOption;
    }
}