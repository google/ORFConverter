/*
  Copyright 2015 Google Inc. All Rights Reserved.

  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
*/

using System;
using System.Windows.Forms;

namespace ORFConverter {
  public partial class FormMain : Form {
    public FormMain() {
      InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e) {
      // Display version number in app title bar.
      System.Reflection.Assembly assembly =
          System.Reflection.Assembly.GetExecutingAssembly();
      Text += ' ' + assembly.GetName().Version.ToString();

      // Apply conversion target setting.
      if (Properties.Settings.Default.ConversionTarget ==
          (int)Converter.ConversionTarget.EM10) {
        radioButtonEM10.Checked = true;
      } else if (Properties.Settings.Default.ConversionTarget ==
            (int)Converter.ConversionTarget.EM10MarkII) {
        radioButtonEM10MarkII.Checked = true;
      }
      // Apply destination mode setting.
      if (Properties.Settings.Default.Destination == 0) {
        radioButtonOriginalLocation.Checked = true;
      } else {
        radioButtonFolder.Checked = true;
      }
      radioButtonOriginalLocation_CheckedChanged(null, null);
      radioButtonFolder_CheckedChanged(null, null);
    }

    private void FormMain_FormClosed(object sender, FormClosedEventArgs e) {
      // Store conversion target setting.
      if (radioButtonEM10.Checked) {
        Properties.Settings.Default.ConversionTarget =
            (int)Converter.ConversionTarget.EM10;
      } else if (radioButtonEM10MarkII.Checked) {
        Properties.Settings.Default.ConversionTarget =
            (int)Converter.ConversionTarget.EM10MarkII;
      }
      // Store destination mode setting.
      Properties.Settings.Default.Destination =
          radioButtonOriginalLocation.Checked ? 0 : 1;

      // Save settings.
      global::ORFConverter.Properties.Settings.Default.Save();
    }

    private void radioButtonOriginalLocation_CheckedChanged(
        object sender, EventArgs e) {
      // Enable "overwrite" checkbox only if "original location" checkbox set.
      checkBoxOverwrite.Enabled = radioButtonOriginalLocation.Checked;
    }

    private void radioButtonFolder_CheckedChanged(object sender, EventArgs e) {
      // Enable folder controls only if destination folder checkbox set.
      textBoxFolder.Enabled = radioButtonFolder.Checked;
      buttonFolder.Enabled = radioButtonFolder.Checked;
    }

    private void buttonFolder_Click(object sender, EventArgs e) {
      // Display folder browser dialog.
      if (folderBrowserDialogDestination.ShowDialog() == DialogResult.OK) {
        textBoxFolder.Text = folderBrowserDialogDestination.SelectedPath;
      }
      buttonConvert_UpdateEnabled();
    }

    private void buttonAddFiles_Click(object sender, EventArgs e) {
      // Display file selection dialog.
      if (openFileDialogAddFiles.ShowDialog() == DialogResult.OK) {
        foreach (string filename in openFileDialogAddFiles.FileNames) {
          // Only add the filename if it's not already in the list...
          if (listBoxSources.Items.IndexOf(filename) < 0) {
            // ... and it's an ORF file and actually exists.
            System.IO.FileInfo fi = new System.IO.FileInfo(filename);
            if (fi.Exists &&
                fi.Extension.Equals(".ORF", StringComparison.OrdinalIgnoreCase)) {
              listBoxSources.Items.Add(filename);
            }
          }
        }
      }
      buttonConvert.Enabled = listBoxSources.Items.Count > 0;
    }

    private void buttonReset_Click(object sender, EventArgs e) {
      listBoxSources.Items.Clear();
      buttonConvert_UpdateEnabled();
    }

    private void buttonAddFolder_Click(object sender, EventArgs e) {
      if (folderBrowserDialogAddFolder.ShowDialog() == DialogResult.OK) {
        // Only add selected path if it's not already in the list
        // and the directory actually exists.
        string path = folderBrowserDialogAddFolder.SelectedPath + '\\';
        if (listBoxSources.Items.IndexOf(path) < 0 &&
            new System.IO.DirectoryInfo(path).Exists) {
          listBoxSources.Items.Add(path);
        }
      }
      buttonConvert_UpdateEnabled();
    }

    private void buttonConvert_UpdateEnabled() {
      // Enable the "Convert" button if valid sources and destination set.
      buttonConvert.Enabled = listBoxSources.Items.Count > 0 &&
          (radioButtonOriginalLocation.Checked ||
           textBoxFolder.Text.Length > 0);
    }

    private void buttonConvert_Click(object sender, EventArgs e) {
      // Create new FormResults dialog which will run the conversion
      // and display the conversion status and results.
      FormResults formResults = new FormResults();

      // Transmit the conversion settings to FormResults.
      formResults.recurse = checkBoxIncludeSubfolders.Checked;
      formResults.conversion = radioButtonEM10.Checked ?
          Converter.ConversionTarget.EM10 :
          Converter.ConversionTarget.EM10MarkII;

      // Validate destination folder.
      if (radioButtonFolder.Checked) {
        string destPath = "";
        try {
          // Fully expand the path of the specified destination folder.
          destPath = System.IO.Path.GetFullPath(textBoxFolder.Text);
        } catch {
          // Something wasn't right with the path; notify and exit.
          MessageBox.Show(Properties.Resources.StringErrorDestination,
              this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          textBoxFolder.Focus();
          return;
        }
        // Fetch information about the destination directory.
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(destPath);
        if (!di.Exists) {
          // Destination directory doesn't exist; ask if we should create it.
          if (MessageBox.Show(Properties.Resources.StringCreateDestination,
              this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
            DialogResult.Yes) {
            try {
              // Create the new directory.
              di.Create();
              di.Refresh();
            } catch {
              // Unable to create the new directory; report and exit.
              MessageBox.Show(
                  Properties.Resources.StringErrorCreateDestination,
                  this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              textBoxFolder.Focus();
              return;
            }
          } else {
            // User opted not to create new directory; exit.
            return;
          }
        }
        // Set results directory.
        formResults.destination = di;
      } else {
        formResults.destination = null;
      }
      // Overwrite setting only applies if saving output to original location.
      formResults.overwrite = formResults.destination == null ?
          checkBoxOverwrite.Checked : false;

      // Transmit source items.
      formResults.sourceItems = new string[listBoxSources.Items.Count];
      for (int i = 0; i < listBoxSources.Items.Count; i++) {
        formResults.sourceItems[i] = listBoxSources.Items[i].ToString();
      }

      // FormResults dialog does all the processing.
      if (formResults.ShowDialog() == DialogResult.OK) {
        // If success was reported, clear the list of stuff to convert.
        listBoxSources.Items.Clear();
      }
    }

    private void listBoxSources_DragEnter(object sender, DragEventArgs e) {
      // Only allow files/folders to be dropped into the list.
      e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ?
          DragDropEffects.Copy : DragDropEffects.None;
    }

    private void listBoxSources_DragDrop(object sender, DragEventArgs e) {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        try {
          // Get the paths of files/directories dropped.
          string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
          foreach (string file in paths) {
            try {
              System.IO.FileInfo fi = new System.IO.FileInfo(file);
              if (fi.Exists) {
                // If this item is a file, add it only if it's an ORF file
                // and isn't already in the list.
                if (fi.Extension.Equals(".ORF",
                        StringComparison.OrdinalIgnoreCase) &&
                    listBoxSources.Items.IndexOf(fi.FullName) < 0) {
                  listBoxSources.Items.Add(fi.FullName);
                }
                continue;
              }
              System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(file);
              if (di.Exists) {
                // If this item is a directory, add a trailing backslash to
                // path (so we know it's a directory) and add it only if it's
                // not already on the list.
                string path = di.FullName + '\\';
                if (listBoxSources.Items.IndexOf(path) < 0) {
                  listBoxSources.Items.Add(path);
                }
                continue;
              }
            } catch { }
          }
        } catch { }
        buttonConvert_UpdateEnabled();
      }
    }

    private void textBoxFolder_DragEnter(object sender, DragEventArgs e) {
      // By default, don't accept the drag.
      e.Effect = DragDropEffects.None;

      // For destination we accept only a single existent directory.
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        try {
          string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
          if (files.Length == 1 &&
              new System.IO.DirectoryInfo(files[0]).Exists) {
            e.Effect = DragDropEffects.Copy;
          }
        } catch { }
      }
    }

    private void textBoxFolder_DragDrop(object sender, DragEventArgs e) {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        try {
          // For destination we accept only a single existent directory.
          string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
          System.IO.DirectoryInfo di;
          if (files.Length == 1 &&
              (di = new System.IO.DirectoryInfo(files[0])).Exists) {
            // Set the path into the text box control.
            textBoxFolder.Text = di.FullName;
          }
        } catch { }
      }

      buttonConvert_UpdateEnabled();
    }

    private void textBoxFolder_TextChanged(object sender, EventArgs e) {
      buttonConvert_UpdateEnabled();
    }
  }
}
