using System;
using System.IO;
using System.Windows.Forms;

namespace NoitaSaveManager
{
    public partial class Form2 : Form
    {
        private string noitaSaveFolder;

        public Form2(string saveFolder)
        {
            InitializeComponent();
            noitaSaveFolder = saveFolder;
        }

        private void buttonCopyFolder_Click(object sender, EventArgs e)
        {
            // Prompt for the new folder name
            using (var prompt = new FolderNamePrompt())
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    string newFolderName = prompt.FolderName;
                    if (!string.IsNullOrWhiteSpace(newFolderName))
                    {
                        string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newFolderName);

                        // Create the new directory
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }

                        // Define the source folder
                        string sourceFolder = Path.Combine(noitaSaveFolder, "save00");

                        // Check if the source folder exists
                        if (Directory.Exists(sourceFolder))
                        {
                            // Copy the contents
                            CopyDirectory(sourceFolder, destinationFolder);
                            MessageBox.Show($"Folder copied to {destinationFolder}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The source folder 'save00' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid folder name.", "Invalid Folder Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            // Copy all files
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            // Copy all subdirectories
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
                Directory.CreateDirectory(destSubDir);
                CopyDirectory(subDir, destSubDir);
            }
        }
    }
}
