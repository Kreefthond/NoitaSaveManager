using System;
using System.Windows.Forms;

namespace NoitaSaveManager
{
    public partial class FolderNamePrompt : Form
    {
        public string FolderName { get; private set; }

        public FolderNamePrompt()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFolderName.Text))
            {
                MessageBox.Show("Please enter a valid folder name.", "Invalid Folder Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FolderName = textBoxFolderName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
