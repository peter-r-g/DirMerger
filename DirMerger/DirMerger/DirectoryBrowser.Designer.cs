namespace DirMerger
{
    partial class DirectoryBrowser
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
            this.dirTreeView = new System.Windows.Forms.TreeView();
            this.dirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.itemNotesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // dirTreeView
            // 
            this.dirTreeView.Location = new System.Drawing.Point(12, 13);
            this.dirTreeView.Name = "dirTreeView";
            this.dirTreeView.Size = new System.Drawing.Size(460, 374);
            this.dirTreeView.TabIndex = 0;
            this.dirTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.DirTreeView_BeforeExpand);
            this.dirTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DirTreeView_NodeMouseClick);
            this.dirTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DirTreeView_NodeMouseDoubleClick);
            // 
            // dirBrowser
            // 
            this.dirBrowser.HelpRequest += new System.EventHandler(this.DirBrowser_HelpRequest);
            // 
            // itemNotesRichTextBox
            // 
            this.itemNotesRichTextBox.Location = new System.Drawing.Point(12, 393);
            this.itemNotesRichTextBox.Name = "itemNotesRichTextBox";
            this.itemNotesRichTextBox.Size = new System.Drawing.Size(460, 156);
            this.itemNotesRichTextBox.TabIndex = 1;
            this.itemNotesRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.itemNotesRichTextBox);
            this.Controls.Add(this.dirTreeView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "Form1";
            this.Text = "Directory Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirectoryBrowser_FormClosing);
            this.Load += new System.EventHandler(this.DirectoryBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView dirTreeView;
        private System.Windows.Forms.FolderBrowserDialog dirBrowser;
        private System.Windows.Forms.RichTextBox itemNotesRichTextBox;
    }
}

