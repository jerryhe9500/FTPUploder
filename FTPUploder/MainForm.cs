using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace FTPUploder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            //Choose a sourcee file
            do
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (openFileDialog.OpenFile() != null)
                        {
                            fileName = openFileDialog.SafeFileName;
                            sourceFile = openFileDialog.FileName;
                            saveFileDialog.FileName = fileName;
                            MessageBox.Show("source:" + sourceFile);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            } while (sourceFile == null);
            //Choose a destination path
            do
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        destFile = saveFileDialog.FileName;
                        MessageBox.Show("destination:" + destFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                    }
                }
            } while (destFile == null);

            //Provide a standard dialog box that shows progress on file operations in Windows
            try
            {
                FileSystem.CopyFile(sourceFile, destFile, UIOption.AllDialogs);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
