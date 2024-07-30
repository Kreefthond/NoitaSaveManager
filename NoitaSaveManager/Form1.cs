using System;
using System.IO;
using System.Windows.Forms;

namespace NoitaSaveManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Set initial state of the manual input box and buttons
            textBoxManualPath.Visible = false;
            buttonSavePath.Visible = false;
            buttonContinue.Visible = false;
            buttonRestoreSave.Visible = false;  // Hide the restore save button initially
            buttonConfirmRestore.Visible = false;  // Hide the confirm restore button initially

            // Subscribe to the ComboBox event
            comboBoxFolderList.SelectedIndexChanged += ComboBoxFolderList_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get Noita save path and display it in textBox1
            string noitaPath = GetNoitaSavePath();

            if (noitaPath != null)
            {
                textBox1.Text = noitaPath;
                textBoxManualPath.Visible = false;
                buttonSavePath.Visible = false;
                buttonContinue.Visible = true;  // Show the continue button
                buttonRestoreSave.Visible = true;  // Show the restore save button
            }
            else
            {
                textBox1.Text = "Noita save folder not found.";
                textBoxManualPath.Visible = true;
                buttonSavePath.Visible = true;
                buttonContinue.Visible = false;  // Hide the continue button until a path is entered manually
                buttonRestoreSave.Visible = false;  // Hide the restore save button until a valid path is found
            }
        }

        private string GetNoitaSavePath()
        {
            // Get the current user's name
            string userName = Environment.UserName;
            // Construct the expected Noita save path with the current user's name
            string noitaSavePath = Path.Combine(@"C:\Users", userName, "AppData", "LocalLow", "Nolla_Games_Noita");

            // Check if the Noita save folder exists
            if (Directory.Exists(noitaSavePath))
            {
                return noitaSavePath;
            }

            return null;
        }

        private void buttonSavePath_Click(object sender, EventArgs e)
        {
            string manualPath = textBoxManualPath.Text;

            if (Directory.Exists(manualPath))
            {
                textBox1.Text = manualPath;
                buttonContinue.Visible = true;
                buttonRestoreSave.Visible = true;  // Show the restore save button when a valid path is entered
            }
            else
            {
                MessageBox.Show("Please enter a valid path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonContinue.Visible = false;
                buttonRestoreSave.Visible = false;  // Hide the restore save button if the path is invalid
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            string noitaSavePath = textBox1.Text;
            string sourceFolder = Path.Combine(noitaSavePath, "save00");

            if (Directory.Exists(sourceFolder))
            {
                using (var prompt = new FolderNamePrompt())
                {
                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        string folderName = prompt.FolderName;
                        string targetFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);

                        // Create the target folder and copy files
                        DirectoryCopy(sourceFolder, targetFolder);

                        MessageBox.Show("Save folder copied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("The source save folder 'save00' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRestoreSave_Click(object sender, EventArgs e)
        {
            // List all folders in the NoitaSaveManager directory and populate the ComboBox
            string noitaSaveManagerPath = AppDomain.CurrentDomain.BaseDirectory;
            string[] folders = Directory.GetDirectories(noitaSaveManagerPath);

            comboBoxFolderList.Items.Clear();
            foreach (var folder in folders)
            {
                comboBoxFolderList.Items.Add(Path.GetFileName(folder));
            }

            comboBoxFolderList.Visible = true;  // Show the ComboBox for folder selection
            buttonConfirmRestore.Visible = true;  // Show the confirm restore button
        }

        private void buttonConfirmRestore_Click(object sender, EventArgs e)
        {
            string selectedFolder = comboBoxFolderList.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedFolder))
            {
                MessageBox.Show("Please select a folder from the list.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string noitaSavePath = textBox1.Text;
            string sourceFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, selectedFolder);
            string targetFolder = Path.Combine(noitaSavePath, "save00");

            try
            {
                // Delete the existing 'save00' folder
                if (Directory.Exists(targetFolder))
                {
                    Directory.Delete(targetFolder, true);
                }

                // Copy the selected folder to 'save00'
                DirectoryCopy(sourceFolder, targetFolder);

                MessageBox.Show("Save folder restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring save folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonConfirmRestore.Visible = comboBoxFolderList.SelectedIndex >= 0;
        }

        private void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Create destination directory if it doesn't exist
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Copy files
            foreach (string file in Directory.GetFiles(sourceDirName))
            {
                string destFile = Path.Combine(destDirName, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            // Copy subdirectories
            foreach (string subdir in Directory.GetDirectories(sourceDirName))
            {
                string destSubDir = Path.Combine(destDirName, Path.GetFileName(subdir));
                DirectoryCopy(subdir, destSubDir);
            }
        }
    }
}
