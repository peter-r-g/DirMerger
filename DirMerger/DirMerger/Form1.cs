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
    public partial class Form1 : Form
    {
        private string resourceDir = Application.StartupPath + "\\resource\\";
        public string curDir = Environment.CurrentDirectory;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load tree view images
            ImageList treeViewImages = new ImageList();
            treeViewImages.Images.Add(Image.FromFile(resourceDir + "file-icon.png"));
            treeViewImages.Images.Add(Image.FromFile(resourceDir + "folder-icon.png"));

            dirTreeView.ImageList = treeViewImages;

            // Get the folder we're working in
            DialogResult result = dirBrowser.ShowDialog();

            // Make sure we actually got a folder
            if (result == DialogResult.OK)
                curDir = dirBrowser.SelectedPath;
            else
                throw new Exception("Program did not receive a directory to use!");

            // Get all directories and files in there
            string[] directories = Directory.GetDirectories(curDir);
            string[] files = Directory.GetFiles(curDir);

            // Start updating the tree view
            dirTreeView.BeginUpdate();
            foreach (string dir in directories)
            {
                string formattedDir = dir.Replace(curDir, "");
                TreeNode dirNode = new TreeNode(formattedDir);
                dirNode.ImageIndex = 1;
                dirTreeView.Nodes.Add(dirNode);
            }
            foreach (string file in files)
            {
                string formattedFile = file.Replace(curDir, "");
                TreeNode fileNode = new TreeNode(formattedFile);
                fileNode.ImageIndex = 0;
                dirTreeView.Nodes.Add(fileNode);
            }
            dirTreeView.EndUpdate();
        }

        private void DirBrowser_HelpRequest(object sender, EventArgs e)
        {
            
        }
    }
}
