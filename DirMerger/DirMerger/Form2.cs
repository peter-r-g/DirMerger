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
    public partial class Form2 : Form
    {
        public string filePath;

        bool editing = false;
        bool saved = true;

        public Form2(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
        }

        private void SaveFile()
        {
            saved = true;
            File.WriteAllLines(filePath, codeViewer.Lines);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Code Viewer - " + filePath;

            string[] fileLines = File.ReadAllLines(filePath);
            codeViewer.Lines = fileLines;
            saved = true;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show("There are changes to this file that haven't been saved, would you like to save the file?", "Unsaved File", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    SaveFile();
            }
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Size newSize = this.Size;
            codeViewer.Location = new Point(12, 27);
            codeViewer.Size = new Size(newSize.Width - 40, newSize.Height - 78);
        }

        private void CodeViewer_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void EditingOption_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                editing = false;
                editingOption.Text = "Start Editing";
                codeViewer.ReadOnly = true;
            }
            else
            {
                editing = true;
                editingOption.Text = "Stop Editing";
                codeViewer.ReadOnly = false;
            }
        }

        private void SaveOption_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void TextZoomOption_Click(object sender, EventArgs e)
        {
            codeViewer.ZoomFactor = float.Parse(sender.ToString().Replace('x', ' '));
        }
    }
}
