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
        private readonly string resourceDir = Application.StartupPath + "\\resource\\";
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


            // Start updating the tree view
            dirTreeView.BeginUpdate();

            // Create the root node
            TreeNode rootNode = new TreeNode(curDir);
            rootNode.ImageIndex = 1;
            dirTreeView.Nodes.Add(rootNode);

            // Search every dir and file to create the tree view
            SearchDir(curDir, dirTreeView.Nodes[0]);

            dirTreeView.EndUpdate();
        }

        private void DirBrowser_HelpRequest(object sender, EventArgs e)
        {
            
        }

        TreeNode GetNode(int[] nodePath)
        {
            TreeNode curNode = dirTreeView.Nodes[0];

            foreach (int nodeIndex in nodePath)
            {
                curNode = curNode.Nodes[nodeIndex];
            }

            return curNode;
        }

        public void SearchDir(string dir, TreeNode parentNode)
        {
            Debug.Print(dir);
            string[] directories = Directory.GetDirectories(dir);
            string[] files = Directory.GetFiles(dir);

            foreach (string _dir in directories)
            {
                string formattedDir = _dir.Replace(curDir, "");
                TreeNode dirNode = new TreeNode(formattedDir);
                dirNode.ImageIndex = 1;
                parentNode.Nodes.Add(dirNode);
                SearchDir(_dir, dirNode);
            }
            foreach (string file in files)
            {
                string formattedFile = file.Replace(curDir, "");
                TreeNode fileNode = new TreeNode(formattedFile);
                fileNode.ImageIndex = 0;
                parentNode.Nodes.Add(fileNode);
            }
        }
    }
}
