using System;
using System.IO;
using Google.Apis.Drive.v2.Data;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        //Local variable with private get and private set.
        private DriveHandler google_api { get; set; }
        
        //GUI startup
        public Form1()
        {
            InitializeComponent();
        }

        //Our Test Button callback
        private void test_button_Click(object sender, EventArgs e)
        {
            
            test();

            //file_watcher.Path = ;
        }

        //Called when the path in Local Path selection is changed
        //sets/resets the File System Watcher to handle callbacks
        private void local_path_PathChanged(object sender, EventArgs e)
        {
            file_watcher.Path = local_path.Text;
            file_watcher.IncludeSubdirectories = true;
            file_watcher.InitializeLifetimeService();
            file_watcher.NotifyFilter = NotifyFilters.LastAccess| NotifyFilters.LastWrite|NotifyFilters.FileName|NotifyFilters.DirectoryName;
            file_watcher.Filter = "*.*";
            file_watcher.EnableRaisingEvents = true;

        }

        // File System Watcher Callback Methods
        private void file_renamed(object source, FileSystemEventArgs the_file)
        {
            var file_path = the_file.FullPath;
            file_watcher_log.AppendText("FILE RENAMED: " + file_path + "\r\n");
            //TODO: call a DriveHandler method to rename the changed file
        }

        private void file_deleted(object source, FileSystemEventArgs the_file)
        {
            var file_path = the_file.FullPath;
            var file_name = the_file.Name;
            file_watcher_log.AppendText("FILE DELETED: " + file_name + " " + file_path + "\r\n");
            //TODO: call a DriveHandler method to delete the file
        }
        private void file_created(object source, FileSystemEventArgs the_file)
        {
            var file_path = the_file.FullPath;
            var file_name = the_file.Name;
            file_watcher_log.AppendText("FILE CREATED: " + file_name + " " + file_path + "\r\n");
            //TODO: call a DriveHandler method to upload the created file
        }

        private void file_changed(object source, FileSystemEventArgs the_file)
        {
            var file_path = the_file.FullPath;
            var file_name = the_file.Name;
            file_watcher_log.AppendText("FILE CHANGE: "+file_name+" "+file_path + "\r\n");
            //TODO: call a DriveHandler method to upload the changed file
        }
        // --------------------------------- //

        private void local_path_Click(object sender, EventArgs e)
        {
            DialogResult result = select_local_folder.ShowDialog();
            if (DialogResult.OK == result)
            {
                local_path.Text = select_local_folder.SelectedPath;
            }
        }

        //BUTTON TEST
        private void test()
        {
            this.google_api = new DriveHandler();
            //google_api.GetFiles("name contains '" + google_drive_folder.Text + "' and mimeType = 'application/vnd.google-apps.folder'");
            var folders_on_google = this.google_api.GetFolders ();
            if (folders_on_google != null)
            {
                // Adding each Folder  to the list.
                foreach (Google.Apis.Drive.v2.Data.File item in folders_on_google)
                {
                    string[] arr = new string[2];
                    ListViewItem itm;
                    //add items to ListView
                    arr[0] = item.Title;
                    arr[1] = item.Id;
                    itm = new ListViewItem(arr);
                    google_drive_folders.Items.Add(itm);

                }
            }
        }

        //CALLED WHEN USER SELECT ITEM ON LIST
        private void google_drive_folders_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected_Index = google_drive_folders.SelectedItems;
            if (selected_Index.Count > 0)
            {
                var google_selected_FolderId = selected_Index[0].SubItems[1].Text;
                this.google_api.sync_folder_id = google_selected_FolderId;

                //TODO:begin sync of local folder with Google Drive Folder
            }
        }
    }
}
