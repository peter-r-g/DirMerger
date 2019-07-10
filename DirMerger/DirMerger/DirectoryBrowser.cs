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
    public partial class DirectoryBrowser : Form
    {
        private readonly string resourceDir = Application.StartupPath + "\\resource\\";
        public string curDir = Environment.CurrentDirectory;

        Dictionary<string, string[]> itemNotesDictionary = new Dictionary<string, string[]>();
        string[] codeViewerExtensions;
        TreeNode curSelectedNode;

        public CodeViewer codeViewer = new CodeViewer();

        public DirectoryBrowser()
        {
            InitializeComponent();
        }

        public void SearchDir(string dir, TreeNode parentNode)
        {
            string[] directories = Directory.GetDirectories(dir);

            // If the directory has no directories in it then add an empty node so we can check if it has files later
            if (directories.Length == 0)
            {
                parentNode.Nodes.Add("<EMPTY>");
                return;
            }

            // Add each directory
            foreach (string _dir in directories)
            {
                string formattedDir = _dir.Replace(dir, "");
                TreeNode dirNode = new TreeNode(formattedDir);
                dirNode.ImageIndex = 1;
                dirNode.SelectedImageIndex = 1;
                parentNode.Nodes.Add(dirNode);
                SearchDir(_dir, dirNode);
            }
        }

        public string GetNodeFilePath(TreeNode node)
        {
            TreeNode curNode = node;
            string filePath = curNode.Text;

            // Build the file path
            while (curNode.Parent != null)
            {
                curNode = curNode.Parent;
                filePath = curNode.Text + filePath;
            }

            return filePath;
        }

        public bool ValidFileExtension(string extension)
        {
            foreach (string ext in codeViewerExtensions)
            {
                if (extension == ext)
                    return true;
            }

            return false;
        }

        private void DirectoryBrowser_Load(object sender, EventArgs e)
        {
            // Load tree view images
            ImageList treeViewImages = new ImageList();
            treeViewImages.Images.Add(Image.FromFile(resourceDir + "file-icon.png"));
            treeViewImages.Images.Add(Image.FromFile(resourceDir + "folder-icon.png"));

            dirTreeView.ImageList = treeViewImages;

            // Load code viewer extensions
            codeViewerExtensions = File.ReadAllLines(resourceDir + "code-extensions.dat");

            // Get the folder we're working in
            DialogResult result = dirBrowser.ShowDialog();

            // Make sure we actually got a folder
            if (result == DialogResult.OK)
                curDir = dirBrowser.SelectedPath;
            else
                Application.Exit();

            // Change the title to show the folder we're working in
            this.Text = "Directory Browser - " + curDir;

            // Check if this directory has already been looked into
            if (File.Exists(curDir + "\\dir-merger_data.dat"))
            {
                string[] fileLines = File.ReadAllLines(curDir + "\\dir-merger_data.dat");

                // Decrypt the data back into a usable format
                foreach (string fileLine in fileLines)
                {
                    string[] split = { "<EQUALS>", "<NEW_LINE>" };
                    string[] keyValue = fileLine.Split(split, 2, StringSplitOptions.None);
                    string[] itemNotes = keyValue[1].Split(split, StringSplitOptions.None);

                    itemNotesDictionary[keyValue[0]] = itemNotes;
                }
            }

            // Start updating the tree view
            dirTreeView.BeginUpdate();

            // Create the root node
            TreeNode rootNode = new TreeNode(curDir);
            rootNode.ImageIndex = 1;
            rootNode.SelectedImageIndex = 1;
            dirTreeView.Nodes.Add(rootNode);

            // Search every dir and file to create the tree view
            SearchDir(curDir, dirTreeView.Nodes[0]);

            dirTreeView.EndUpdate();
        }

        private void DirectoryBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> fileLines = new List<string>();

            // Loop through every dictionary 
            foreach (KeyValuePair<string, string[]> itemNotes in itemNotesDictionary)
            {
                // Ignore empty entries
                if (itemNotes.Value.Length == 0 || itemNotes.Value[0] == "")
                    continue;

                string fileLine = itemNotes.Key;
                string notes = "";

                // Build the notes
                foreach (string line in itemNotes.Value)
                {
                    notes += line + "<NEW_LINE>";
                }

                // Finish off the line
                fileLine += "<EQUALS>" + notes;
                fileLines.Add(fileLine);
            }

            // Write all the data if we have any
            if (fileLines.Count > 0)
                File.WriteAllLines(curDir + "\\dir-merger_data.dat", fileLines.ToArray());

            // Close the entire program since we are now done
            Application.Exit();
        }

        private void DirTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // Remove the empty node if it exists
            if (e.Node.Nodes[0].Text == "<EMPTY>")
                e.Node.Nodes[0].Remove();
            else
                return;

            string filePath = GetNodeFilePath(e.Node);

            // Add the file nodes
            string[] files = Directory.GetFiles(filePath);
            foreach (string file in files)
            {
                string formattedFile = file.Replace(filePath, "");
                TreeNode fileNode = new TreeNode(formattedFile);
                fileNode.ImageIndex = 0;
                fileNode.SelectedImageIndex = 0;
                e.Node.Nodes.Add(fileNode);
            }
        }

        private void DirTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // If there was a node already being worked on then save that
            if (curSelectedNode != null)
                itemNotesDictionary[GetNodeFilePath(curSelectedNode)] = itemNotesRichTextBox.Lines;

            curSelectedNode = e.Node;
            string filePath = GetNodeFilePath(e.Node);
            string[] itemNotes = {  };

            // See if there is an entry to this item already
            try
            {
                itemNotesDictionary.TryGetValue(filePath, out itemNotes);
            }
            catch (ArgumentNullException exception)
            {
                itemNotesDictionary[filePath] = itemNotes;
            }

            // Setup the rich text box
            itemNotesRichTextBox.Lines = itemNotes;
        }

        private void DirTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] nodeTextPieces = e.Node.Text.Split('.');

            // Check that the file we're trying to open is a valid file
            if (ValidFileExtension(nodeTextPieces[nodeTextPieces.Length-1]))
            {
                string filePath = GetNodeFilePath(e.Node);

                codeViewer.CodeViewer_FormClosing(new object(), new FormClosingEventArgs(CloseReason.None, false));
                codeViewer.Setup(filePath);
                codeViewer.CodeViewer_Load(new object(), new EventArgs());
                if (!codeViewer.Visible)
                    codeViewer.Show();
            }
        }

        private void DirBrowser_HelpRequest(object sender, EventArgs e) {  }
    }
}
