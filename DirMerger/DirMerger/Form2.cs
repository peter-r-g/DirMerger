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
            string[] fileLines = File.ReadAllLines(filePath);
            codeViewer.Lines = fileLines;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Size newSize = Form2.ActiveForm.Size;
            codeViewer.Location = new Point(12, 12);
            codeViewer.Size = new Size(newSize.Width - 40, newSize.Height - 63);
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.Print("Hello?");
            if (e.Button == MouseButtons.Right)
            {
                Debug.Print("Hello Again!");
                contextMenu.Location = new Point(e.X, e.Y);
                contextMenu.Show();
            }
        }

        private void CodeViewer_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.Print("Hello?");
            if (e.Button == MouseButtons.Right)
            {
                Debug.Print("Hello Again!");
                contextMenu.Location = new Point(e.X, e.Y);
                contextMenu.Show();
            }
        }

        private void ContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Debug.Print("Hello?");
            if (e.ClickedItem.GetCurrentParent().Text == "Text Zoom")
            {
                Debug.Print("Hello Again!");
                switch (e.ClickedItem.Text)
                {
                    case "0.5x":
                        codeViewer.ZoomFactor = 0.5f;
                        break;
                    case "1x":
                        codeViewer.ZoomFactor = 1;
                        break;
                    case "1.5x":
                        codeViewer.ZoomFactor = 1.5f;
                        break;
                    case "2x":
                        codeViewer.ZoomFactor = 2;
                        break;
                }
            }
        }
    }
}
