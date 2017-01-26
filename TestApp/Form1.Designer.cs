using System.IO;
using System.Windows.Forms;

namespace TestApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.test_button = new System.Windows.Forms.Button();
            this.local_path_label = new System.Windows.Forms.Label();
            this.file_watcher = new System.IO.FileSystemWatcher();
            this.local_path = new System.Windows.Forms.TextBox();
            this.select_local_folder = new System.Windows.Forms.FolderBrowserDialog();
            this.google_drive_folders = new System.Windows.Forms.ListView();
            this.file_watcher_log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.file_watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // test_button
            // 
            this.test_button.Location = new System.Drawing.Point(16, 38);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(167, 23);
            this.test_button.TabIndex = 0;
            this.test_button.Text = "Connect To Google Drive";
            this.test_button.UseVisualStyleBackColor = true;
            this.test_button.Click += new System.EventHandler(this.test_button_Click);
            // 
            // local_path_label
            // 
            this.local_path_label.AutoSize = true;
            this.local_path_label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.local_path_label.Location = new System.Drawing.Point(12, 9);
            this.local_path_label.Name = "local_path_label";
            this.local_path_label.Size = new System.Drawing.Size(160, 23);
            this.local_path_label.TabIndex = 1;
            this.local_path_label.Text = "Select Local Folder :";
            // 
            // file_watcher
            // 
            this.file_watcher.EnableRaisingEvents = true;
            this.file_watcher.IncludeSubdirectories = true;
            this.file_watcher.SynchronizingObject = this;
            this.file_watcher.Changed += new System.IO.FileSystemEventHandler(this.file_changed);
            this.file_watcher.Created += new System.IO.FileSystemEventHandler(this.file_created);
            this.file_watcher.Deleted += new System.IO.FileSystemEventHandler(this.file_deleted);
            this.file_watcher.Renamed += new System.IO.RenamedEventHandler(this.file_renamed);
            // 
            // local_path
            // 
            this.local_path.Location = new System.Drawing.Point(177, 12);
            this.local_path.Name = "local_path";
            this.local_path.Size = new System.Drawing.Size(156, 20);
            this.local_path.TabIndex = 2;
            this.local_path.Click += new System.EventHandler(this.local_path_Click);
            this.local_path.TextChanged += new System.EventHandler(this.local_path_PathChanged);
            // 
            // google_drive_folders
            // 
            this.google_drive_folders.FullRowSelect = true;
            this.google_drive_folders.GridLines = true;
            this.google_drive_folders.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.google_drive_folders.Location = new System.Drawing.Point(16, 67);
            this.google_drive_folders.Name = "google_drive_folders";
            this.google_drive_folders.Size = new System.Drawing.Size(167, 195);
            this.google_drive_folders.TabIndex = 6;
            this.google_drive_folders.UseCompatibleStateImageBehavior = false;
            this.google_drive_folders.View = System.Windows.Forms.View.List;
            this.google_drive_folders.SelectedIndexChanged += new System.EventHandler(this.google_drive_folders_SelectedIndexChanged);
            // 
            // file_watcher_log
            // 
            this.file_watcher_log.Location = new System.Drawing.Point(242, 118);
            this.file_watcher_log.Multiline = true;
            this.file_watcher_log.Name = "file_watcher_log";
            this.file_watcher_log.Size = new System.Drawing.Size(363, 214);
            this.file_watcher_log.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(237, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "File Changes Log:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.file_watcher_log);
            this.Controls.Add(this.google_drive_folders);
            this.Controls.Add(this.local_path);
            this.Controls.Add(this.local_path_label);
            this.Controls.Add(this.test_button);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.file_watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button test_button;
        private System.Windows.Forms.Label local_path_label;
        private System.IO.FileSystemWatcher file_watcher;
        private System.Windows.Forms.TextBox local_path;
        private System.Windows.Forms.FolderBrowserDialog select_local_folder;
        private System.Windows.Forms.ListView google_drive_folders;
        private Label label1;
        private TextBox file_watcher_log;
    }
}

