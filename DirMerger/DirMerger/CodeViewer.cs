using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirMerger
{
    public partial class CodeViewer : Form
    {
        public string filePath;

        bool editing = false;
        bool saved = true;

        EditItemNotes editItemNotes;

        public CodeViewer()
        {
            InitializeComponent();
        }

        public void Setup(string filePath)
        {
            this.filePath = filePath;
            editItemNotes = new EditItemNotes(this.filePath);
        }

        private void SaveFile()
        {
            saved = true;
            File.WriteAllLines(filePath, codeViewerTextBox.Lines);
        }

        public void CodeViewer_Load(object sender, EventArgs e)
        {
            this.Text = "Code Viewer - " + filePath;

            string[] fileLines = File.ReadAllLines(filePath);
            codeViewerTextBox.Lines = fileLines;
            saved = true;
        }

        public void CodeViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show("There are changes to this file that haven't been saved, would you like to save the file?", "Unsaved File", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    SaveFile();
            }

            e.Cancel = true;
            Hide();
        }

        private void CodeViewer_Resize(object sender, EventArgs e)
        {
            Size newSize = this.Size;
            codeViewerTextBox.Location = new Point(12, 27);
            codeViewerTextBox.Size = new Size(newSize.Width - 40, newSize.Height - 78);
        }

        private void CodeViewerTextBox_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void EditingOption_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                editing = false;
                editingOption.Text = "Start Editing";
                codeViewerTextBox.ReadOnly = true;
            }
            else
            {
                editing = true;
                editingOption.Text = "Stop Editing";
                codeViewerTextBox.ReadOnly = false;
            }
        }

        private void SaveOption_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void TextZoomOption_Click(object sender, EventArgs e)
        {
            codeViewerTextBox.ZoomFactor = float.Parse(sender.ToString().Replace('x', ' '));
        }

        private void ItemNotesOption_Click(object sender, EventArgs e)
        {
            editItemNotes.Show();
        }
    }
}
