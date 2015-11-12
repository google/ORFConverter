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
  partial class FormMain {
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
      listBoxSources = new System.Windows.Forms.ListBox();
      buttonAddFiles = new System.Windows.Forms.Button();
      buttonReset = new System.Windows.Forms.Button();
      groupBox1 = new System.Windows.Forms.GroupBox();
      radioButtonEM10MarkII = new System.Windows.Forms.RadioButton();
      radioButtonEM10 = new System.Windows.Forms.RadioButton();
      groupBox2 = new System.Windows.Forms.GroupBox();
      buttonAddFolder = new System.Windows.Forms.Button();
      checkBoxIncludeSubfolders = new System.Windows.Forms.CheckBox();
      groupBox3 = new System.Windows.Forms.GroupBox();
      buttonFolder = new System.Windows.Forms.Button();
      textBoxFolder = new System.Windows.Forms.TextBox();
      checkBoxOverwrite = new System.Windows.Forms.CheckBox();
      radioButtonFolder = new System.Windows.Forms.RadioButton();
      radioButtonOriginalLocation =
          new System.Windows.Forms.RadioButton();
      buttonConvert = new System.Windows.Forms.Button();
      folderBrowserDialogDestination =
          new System.Windows.Forms.FolderBrowserDialog();
      openFileDialogAddFiles = new System.Windows.Forms.OpenFileDialog();
      folderBrowserDialogAddFolder =
          new System.Windows.Forms.FolderBrowserDialog();
      groupBox1.SuspendLayout();
      groupBox2.SuspendLayout();
      groupBox3.SuspendLayout();
      SuspendLayout();
      // 
      // listBoxSources
      // 
      listBoxSources.AllowDrop = true;
      listBoxSources.FormattingEnabled = true;
      listBoxSources.HorizontalScrollbar = true;
      listBoxSources.IntegralHeight = false;
      listBoxSources.ItemHeight = 31;
      listBoxSources.Location = new System.Drawing.Point(17, 37);
      listBoxSources.Name = "listBoxSources";
      listBoxSources.SelectionMode =
          System.Windows.Forms.SelectionMode.MultiExtended;
      listBoxSources.Size = new System.Drawing.Size(931, 697);
      listBoxSources.Sorted = true;
      listBoxSources.TabIndex = 0;
      listBoxSources.DragDrop +=
          new System.Windows.Forms.DragEventHandler(
              listBoxSources_DragDrop);
      listBoxSources.DragEnter +=
          new System.Windows.Forms.DragEventHandler(
              listBoxSources_DragEnter);
      // 
      // buttonAddFiles
      // 
      buttonAddFiles.Location = new System.Drawing.Point(591, 751);
      buttonAddFiles.Name = "buttonAddFiles";
      buttonAddFiles.Size = new System.Drawing.Size(200, 59);
      buttonAddFiles.TabIndex = 3;
      buttonAddFiles.Text = "&Add files...";
      buttonAddFiles.UseVisualStyleBackColor = true;
      buttonAddFiles.Click += new System.EventHandler(
          buttonAddFiles_Click);
      // 
      // buttonReset
      // 
      buttonReset.Location = new System.Drawing.Point(797, 751);
      buttonReset.Name = "buttonReset";
      buttonReset.Size = new System.Drawing.Size(150, 59);
      buttonReset.TabIndex = 4;
      buttonReset.Text = "&Reset";
      buttonReset.UseVisualStyleBackColor = true;
      buttonReset.Click += new System.EventHandler(
          buttonReset_Click);
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(radioButtonEM10MarkII);
      groupBox1.Controls.Add(radioButtonEM10);
      groupBox1.Location = new System.Drawing.Point(998, 16);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(555, 130);
      groupBox1.TabIndex = 1;
      groupBox1.TabStop = false;
      groupBox1.Text = "Convert &to";
      // 
      // radioButtonEM10MarkII
      // 
      radioButtonEM10MarkII.AutoSize = true;
      radioButtonEM10MarkII.Location = new System.Drawing.Point(16, 79);
      radioButtonEM10MarkII.Name = "radioButtonEM10MarkII";
      radioButtonEM10MarkII.Size = new System.Drawing.Size(306, 36);
      radioButtonEM10MarkII.TabIndex = 1;
      radioButtonEM10MarkII.Text = "OM-D E-M10 Mark II";
      radioButtonEM10MarkII.UseVisualStyleBackColor = true;
      // 
      // radioButtonEM10
      // 
      radioButtonEM10.AutoSize = true;
      radioButtonEM10.Location = new System.Drawing.Point(16, 37);
      radioButtonEM10.Name = "radioButtonEM10";
      radioButtonEM10.Size = new System.Drawing.Size(216, 36);
      radioButtonEM10.TabIndex = 0;
      radioButtonEM10.TabStop = true;
      radioButtonEM10.Text = "OM-D E-M10";
      radioButtonEM10.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(buttonAddFolder);
      groupBox2.Controls.Add(checkBoxIncludeSubfolders);
      groupBox2.Controls.Add(buttonAddFiles);
      groupBox2.Controls.Add(buttonReset);
      groupBox2.Controls.Add(listBoxSources);
      groupBox2.Location = new System.Drawing.Point(16, 16);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new System.Drawing.Size(966, 826);
      groupBox2.TabIndex = 0;
      groupBox2.TabStop = false;
      groupBox2.Text =
          "&Items to convert (add or drop files and folders here)";
      // 
      // buttonAddFolder
      // 
      buttonAddFolder.Location = new System.Drawing.Point(385, 751);
      buttonAddFolder.Name = "buttonAddFolder";
      buttonAddFolder.Size = new System.Drawing.Size(200, 59);
      buttonAddFolder.TabIndex = 2;
      buttonAddFolder.Text = "A&dd folder...";
      buttonAddFolder.UseVisualStyleBackColor = true;
      buttonAddFolder.Click +=
          new System.EventHandler(buttonAddFolder_Click);
      // 
      // checkBoxIncludeSubfolders
      // 
      checkBoxIncludeSubfolders.AutoSize = true;
      checkBoxIncludeSubfolders.Checked =
          global::ORFConverter.Properties.Settings.Default.Recurse;
      checkBoxIncludeSubfolders.CheckState =
          System.Windows.Forms.CheckState.Checked;
      checkBoxIncludeSubfolders.DataBindings.Add(
          new System.Windows.Forms.Binding(
              "Checked",
              global::ORFConverter.Properties.Settings.Default,
              "Recurse",
              true,
              System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      checkBoxIncludeSubfolders.Location =
          new System.Drawing.Point(17, 763);
      checkBoxIncludeSubfolders.Name = "checkBoxIncludeSubfolders";
      checkBoxIncludeSubfolders.Size = new System.Drawing.Size(284, 36);
      checkBoxIncludeSubfolders.TabIndex = 1;
      checkBoxIncludeSubfolders.Text = "Include &subfolders";
      checkBoxIncludeSubfolders.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      groupBox3.Controls.Add(buttonFolder);
      groupBox3.Controls.Add(textBoxFolder);
      groupBox3.Controls.Add(checkBoxOverwrite);
      groupBox3.Controls.Add(radioButtonFolder);
      groupBox3.Controls.Add(radioButtonOriginalLocation);
      groupBox3.Location = new System.Drawing.Point(998, 152);
      groupBox3.Name = "groupBox3";
      groupBox3.Size = new System.Drawing.Size(555, 225);
      groupBox3.TabIndex = 2;
      groupBox3.TabStop = false;
      groupBox3.Text = "&Destination";
      // 
      // buttonFolder
      // 
      buttonFolder.Enabled = false;
      buttonFolder.Location = new System.Drawing.Point(485, 165);
      buttonFolder.Name = "buttonFolder";
      buttonFolder.Size = new System.Drawing.Size(49, 38);
      buttonFolder.TabIndex = 4;
      buttonFolder.Text = "&...";
      buttonFolder.UseVisualStyleBackColor = true;
      buttonFolder.Click +=
          new System.EventHandler(buttonFolder_Click);
      // 
      // textBoxFolder
      // 
      textBoxFolder.AllowDrop = true;
      textBoxFolder.DataBindings.Add(new System.Windows.Forms.Binding(
          "Text",
          global::ORFConverter.Properties.Settings.Default,
          "DestinationFolderText",
          true,
          System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      textBoxFolder.Enabled = false;
      textBoxFolder.Location = new System.Drawing.Point(56, 165);
      textBoxFolder.Name = "textBoxFolder";
      textBoxFolder.Size = new System.Drawing.Size(422, 38);
      textBoxFolder.TabIndex = 3;
      textBoxFolder.Text =
          global::ORFConverter.Properties.Settings.Default.
              DestinationFolderText;
      textBoxFolder.TextChanged +=
          new System.EventHandler(textBoxFolder_TextChanged);
      textBoxFolder.DragDrop +=
          new System.Windows.Forms.DragEventHandler(textBoxFolder_DragDrop);
      textBoxFolder.DragEnter +=
          new System.Windows.Forms.DragEventHandler(textBoxFolder_DragEnter);
      // 
      // checkBoxOverwrite
      // 
      checkBoxOverwrite.AutoSize = true;
      checkBoxOverwrite.Checked =
          global::ORFConverter.Properties.Settings.Default.Overwrite;
      checkBoxOverwrite.DataBindings.Add(
          new System.Windows.Forms.Binding(
              "Checked", global::ORFConverter.Properties.Settings.Default,
              "Overwrite",
              true,
              System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      checkBoxOverwrite.Location = new System.Drawing.Point(56, 80);
      checkBoxOverwrite.Name = "checkBoxOverwrite";
      checkBoxOverwrite.Size = new System.Drawing.Size(320, 36);
      checkBoxOverwrite.TabIndex = 1;
      checkBoxOverwrite.Text = "Over&write original file";
      checkBoxOverwrite.UseVisualStyleBackColor = true;
      // 
      // radioButtonFolder
      // 
      radioButtonFolder.AutoSize = true;
      radioButtonFolder.Location = new System.Drawing.Point(16, 122);
      radioButtonFolder.Name = "radioButtonFolder";
      radioButtonFolder.Size = new System.Drawing.Size(141, 36);
      radioButtonFolder.TabIndex = 2;
      radioButtonFolder.Text = "Folder:";
      radioButtonFolder.UseVisualStyleBackColor = true;
      radioButtonFolder.CheckedChanged +=
          new System.EventHandler(radioButtonFolder_CheckedChanged);
      // 
      // radioButtonOriginalLocation
      // 
      radioButtonOriginalLocation.AutoSize = true;
      radioButtonOriginalLocation.Location = new System.Drawing.Point(16, 38);
      radioButtonOriginalLocation.Name = "radioButtonOriginalLocation";
      radioButtonOriginalLocation.Size = new System.Drawing.Size(259, 36);
      radioButtonOriginalLocation.TabIndex = 0;
      radioButtonOriginalLocation.TabStop = true;
      radioButtonOriginalLocation.Text = "Original location";
      radioButtonOriginalLocation.UseVisualStyleBackColor = true;
      radioButtonOriginalLocation.CheckedChanged +=
          new System.EventHandler(radioButtonOriginalLocation_CheckedChanged);
      // 
      // buttonConvert
      // 
      buttonConvert.Enabled = false;
      buttonConvert.Font = new System.Drawing.Font(
          "Arial", 12F, System.Drawing.FontStyle.Bold,
          System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      buttonConvert.Location = new System.Drawing.Point(1233, 762);
      buttonConvert.Name = "buttonConvert";
      buttonConvert.Size = new System.Drawing.Size(320, 80);
      buttonConvert.TabIndex = 3;
      buttonConvert.Text = "&Convert";
      buttonConvert.UseVisualStyleBackColor = true;
      buttonConvert.Click += new System.EventHandler(buttonConvert_Click);
      // 
      // folderBrowserDialogDestination
      // 
      folderBrowserDialogDestination.Description =
          "Select destination folder into which converted files will be " +
          "written:";
      // 
      // openFileDialogAddFiles
      // 
      openFileDialogAddFiles.Filter = "Olympus raw files (*.ORF)|*.ORF";
      openFileDialogAddFiles.Multiselect = true;
      openFileDialogAddFiles.Title = "Select files to convert";
      // 
      // folderBrowserDialogAddFolder
      // 
      folderBrowserDialogAddFolder.Description =
          "Select folder containing files to be converted:";
      folderBrowserDialogAddFolder.ShowNewFolderButton = false;
      // 
      // FormMain
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      AutoSize = true;
      AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      ClientSize = new System.Drawing.Size(1568, 892);
      Controls.Add(buttonConvert);
      Controls.Add(groupBox3);
      Controls.Add(groupBox1);
      Controls.Add(groupBox2);
      MaximizeBox = false;
      Name = "FormMain";
      Padding = new System.Windows.Forms.Padding(12);
      SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      Text = "Olympus RAW File Converter";
      FormClosed +=
          new System.Windows.Forms.FormClosedEventHandler(FormMain_FormClosed);
      Load += new System.EventHandler(FormMain_Load);
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      groupBox2.ResumeLayout(false);
      groupBox2.PerformLayout();
      groupBox3.ResumeLayout(false);
      groupBox3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.ListBox listBoxSources;
    private System.Windows.Forms.Button buttonAddFiles;
    private System.Windows.Forms.Button buttonReset;
    private System.Windows.Forms.RadioButton radioButtonEM10;
    private System.Windows.Forms.RadioButton radioButtonEM10MarkII;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.CheckBox checkBoxIncludeSubfolders;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button buttonFolder;
    private System.Windows.Forms.TextBox textBoxFolder;
    private System.Windows.Forms.CheckBox checkBoxOverwrite;
    private System.Windows.Forms.RadioButton radioButtonFolder;
    private System.Windows.Forms.RadioButton radioButtonOriginalLocation;
    private System.Windows.Forms.Button buttonConvert;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDestination;
    private System.Windows.Forms.OpenFileDialog openFileDialogAddFiles;
    private System.Windows.Forms.Button buttonAddFolder;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogAddFolder;
  }
}

