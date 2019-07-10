using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirMerger
{
    public partial class EditItemNotes : Form
    {
        string filePath;
        bool saved = true;

        public EditItemNotes(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
        }

        private void SaveNotes()
        {
            DirectoryBrowser.itemNotesDictionary[filePath] = itemNotesTextBox.Lines;
        }

        private void EditItemNotes_Load(object sender, EventArgs e)
        {
            string[] itemNotes = {  };

            try
            {
                DirectoryBrowser.itemNotesDictionary.TryGetValue(filePath, out itemNotes);
            }
            catch (ArgumentNullException exception)
            {
                DirectoryBrowser.itemNotesDictionary[filePath] = itemNotes;
            }

            itemNotesTextBox.Lines = itemNotes;
            saved = true;
        }

        private void EditItemNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show("There are changes to the note that haven't been saved, would you like to save it now?", "Unsaved Notes", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    SaveNotes();
            }

            e.Cancel = true;
            Hide();
        }

        private void ItemNotesTextBox_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveNotes();
            Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
            Hide();
        }
    }
}
