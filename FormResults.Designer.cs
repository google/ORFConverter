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

namespace ORFConverter {
  partial class FormResults {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed;
    /// otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      buttonDismiss = new System.Windows.Forms.Button();
      listBoxOutput = new System.Windows.Forms.ListBox();
      progressBarFilesCompleted = new System.Windows.Forms.ProgressBar();
      SuspendLayout();
      // 
      // buttonDismiss
      // 
      buttonDismiss.Location = new System.Drawing.Point(1016, 619);
      buttonDismiss.Name = "buttonDismiss";
      buttonDismiss.Size = new System.Drawing.Size(200, 59);
      buttonDismiss.TabIndex = 2;
      buttonDismiss.Text = "&Dismiss";
      buttonDismiss.UseVisualStyleBackColor = true;
      buttonDismiss.Click += new System.EventHandler(buttonDismiss_Click);
      // 
      // listBoxOutput
      // 
      listBoxOutput.FormattingEnabled = true;
      listBoxOutput.HorizontalScrollbar = true;
      listBoxOutput.ItemHeight = 31;
      listBoxOutput.Location = new System.Drawing.Point(16, 16);
      listBoxOutput.Name = "listBoxOutput";
      listBoxOutput.SelectionMode = System.Windows.Forms.SelectionMode.None;
      listBoxOutput.Size = new System.Drawing.Size(1200, 593);
      listBoxOutput.TabIndex = 0;
      // 
      // progressBarFilesCompleted
      // 
      progressBarFilesCompleted.Location = new System.Drawing.Point(16, 634);
      progressBarFilesCompleted.Name = "progressBarFilesCompleted";
      progressBarFilesCompleted.Size = new System.Drawing.Size(977, 23);
      progressBarFilesCompleted.Step = 1;
      progressBarFilesCompleted.TabIndex = 1;
      // 
      // FormResults
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      AutoSize = true;
      AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      ClientSize = new System.Drawing.Size(1408, 872);
      ControlBox = false;
      Controls.Add(progressBarFilesCompleted);
      Controls.Add(listBoxOutput);
      Controls.Add(buttonDismiss);
      MaximizeBox = false;
      Name = "FormResults";
      Padding = new System.Windows.Forms.Padding(16);
      ShowInTaskbar = false;
      SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      Text = "Conversion results";
      FormClosing += new System.Windows.Forms.FormClosingEventHandler(
          FormResults_FormClosing);
      Load += new System.EventHandler(FormResults_Load);
      Shown += new System.EventHandler(FormResults_Shown);
      ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button buttonDismiss;
    private System.Windows.Forms.ListBox listBoxOutput;
    private System.Windows.Forms.ProgressBar progressBarFilesCompleted;
  }
}
