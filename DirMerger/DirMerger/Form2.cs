using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            string[] fileLines = File.ReadAllLines(filePath);
            codeViewer.Lines = fileLines;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Size newSize = Form2.ActiveForm.Size;
            codeViewer.Location = new Point(12, 12);
            codeViewer.Size = new Size(newSize.Width - 40, newSize.Height - 63);
        }
    }
}
