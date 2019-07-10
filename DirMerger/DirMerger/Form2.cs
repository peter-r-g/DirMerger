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

        public Form2(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Code Viewer - " + this.filePath;

            string[] fileLines = File.ReadAllLines(filePath);
            codeViewer.Lines = fileLines;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Size newSize = Form2.ActiveForm.Size;
            codeViewer.Location = new Point(12, 27);
            codeViewer.Size = new Size(newSize.Width - 40, newSize.Height - 78);
        }

        private void textZoomOption_Click(object sender, EventArgs e)
        {
            codeViewer.ZoomFactor = float.Parse(sender.ToString().Replace('x', ' '));
        }
    }
}
