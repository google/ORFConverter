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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ORFConverter {
  public partial class FormResults : Form {
    public FormResults() {
      InitializeComponent();
    }

    private void FormResults_Load(object sender, EventArgs e) {
      ControlBox = false;
    }

    private void buttonDismiss_Click(object sender, EventArgs e) {
      if (workThread != null &&
          workThread.ThreadState != System.Threading.ThreadState.Stopped) {
        stopThread = true;
        RenameDismissButton(Properties.Resources.StringButtonDismiss);
      } else {
        Close();
      }
    }

    private void FormResults_Shown(object sender, EventArgs e) {
      listBoxOutput.Items.Clear();
      RenameDismissButton(Properties.Resources.StringButtonStop);
      progressBarFilesCompleted.Value = 0;
      completed = false;
      stopThread = false;
      workThread = new System.Threading.Thread(ThreadProc);
      workThread.Start();
    }

    private void FormResults_FormClosing(object sender,
                                         FormClosingEventArgs e) {
      if (workThread.ThreadState != System.Threading.ThreadState.Stopped) {
        e.Cancel = true;
      } else {
        DialogResult = completed ? DialogResult.OK : DialogResult.Cancel;
      }
    }

    private void ThreadProc() {
      int numSuccess = 0;

      try {
        List<string> sourceFiles = new List<string>(sourceItems.Count());
        // Recursive lambda function to scan a directory.
        Action<DirectoryInfo> scanDir = null;
        scanDir = (dir) => {
          // Add all .ORF files in this directory to sourceFiles.
          foreach (FileInfo file in dir.GetFiles("*.ORF")) {
            sourceFiles.Add(file.FullName);
          }
          if (recurse) {
            // Recurse into subdirectories.
            foreach (DirectoryInfo sub in dir.GetDirectories()) {
              scanDir(sub);
            }
          }
        };

        AddOutput(Properties.Resources.StringGatheringStart);
        foreach (string sourceItem in sourceItems) {
          if (stopThread) {
            throw new Exception(Properties.Resources.StringConversionStopped);
          }
          // We marked directories with a trailing backslash.
          if (sourceItem.EndsWith("\\")) {
            DirectoryInfo dirInfo =
                new DirectoryInfo(sourceItem);
            if (dirInfo.Exists) {
              // Scan the specified directory, recursing if enabled.
              scanDir(dirInfo);
            }
          } else {
            sourceFiles.Add(sourceItem);
          }
        }

        SetProgressBarMax(sourceFiles.Count);
        AddOutput(string.Format(Properties.Resources.StringGatheringEnd,
            sourceFiles.Count));

        // Process each source file.
        int progress = 0;
        foreach (string sourceFile in sourceFiles) {
          if (stopThread) {
            throw new Exception(Properties.Resources.StringConversionStopped);
          }
          string destFile = null;
          AddOutput(Properties.Resources.StringProcessingFile + sourceFile);
          if (overwrite) {
            destFile = sourceFile;
          } else {
            try {
              FileInfo fi = new FileInfo(sourceFile);
              string ext = fi.Extension;
              string left;
              if (destination != null) {
                // Build path for the file in the destination directory.
                left = destination.FullName + '\\' +
                    fi.Name.Remove(fi.Name.Length - ext.Length);
              } else {
                // Build path for the file with ".original" added to its name.
                left = fi.FullName.Remove(fi.FullName.Length - ext.Length) +
                    ".original";
              }
              destFile = left + ext;
              // If the file already exists, add " (1)" (etc.) to the name.
              for (int i = 1; new FileInfo(destFile).Exists; i++) {
                destFile = left + '_' + i + ext;
              }
              if (destination == null) {
                // Rename the source file to the backup name.
                File.Move(fi.FullName, destFile);
                fi = new FileInfo(destFile);
                destFile = sourceFile;
              }
              // Copy the original file to the destination.
              fi.CopyTo(destFile);
            } catch {
              continue;
            }
          }
          if (Converter.ConvertORF(destFile, conversion) ==
              Converter.ConversionResult.Success) {
            ++numSuccess;
          }
          // Update progress bar.
          SetProgressBarValue(++progress);
        }
        completed = sourceFiles.Count == numSuccess;
        SetProgressBarValue(sourceFiles.Count);
        AddOutput(string.Format(Properties.Resources.StringDone, numSuccess));
      } catch (Exception exc) {
        if (exc.Message != null) {
          AddOutput(string.Format(exc.Message, numSuccess));
        }
      }

      RenameDismissButton(Properties.Resources.StringButtonDismiss);
    }

    delegate void AddOutputCallback(string output);

    private void AddOutput(string output) {
      if (listBoxOutput.InvokeRequired) {
        AddOutputCallback cb = new AddOutputCallback(AddOutput);
        Invoke(cb, new object[] { output });
      } else {
        listBoxOutput.Items.Add(output);
        listBoxOutput.TopIndex = listBoxOutput.Items.Count - 1;
      }
    }

    delegate void SetProgressBarMaxCallback(int max);

    private void SetProgressBarMax(int max) {
      if (progressBarFilesCompleted.InvokeRequired) {
        SetProgressBarMaxCallback cb =
            new SetProgressBarMaxCallback(SetProgressBarMax);
        Invoke(cb, new object[] { max });
      } else {
        progressBarFilesCompleted.Maximum = max;
      }
    }

    delegate void SetProgressBarValueCallback(int value);

    private void SetProgressBarValue(int value) {
      if (progressBarFilesCompleted.InvokeRequired) {
        SetProgressBarValueCallback cb =
            new SetProgressBarValueCallback(SetProgressBarValue);
        Invoke(cb, new object[] { value });
      } else {
        progressBarFilesCompleted.Value = value;
      }
    }

    delegate void RenameDismissButtonCallback(string text);

    private void RenameDismissButton(string text) {
      if (buttonDismiss.InvokeRequired) {
        RenameDismissButtonCallback cb =
            new RenameDismissButtonCallback(RenameDismissButton);
        Invoke(cb, new object[] { text });
      } else {
        buttonDismiss.Text = text;
      }
    }

    public string[] sourceItems;
    public DirectoryInfo destination;
    public bool recurse;
    public bool overwrite;
    public Converter.ConversionTarget conversion;

    private System.Threading.Thread workThread;
    private bool completed;
    private bool stopThread;
  }
}
