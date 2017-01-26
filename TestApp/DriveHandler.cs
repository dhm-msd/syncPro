using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    class DriveHandler
    {
        public DriveService drive { get; private set; }
        public String sync_folder_id { private get; set; }

        public DriveHandler()
        {
            this.drive = google_api();
        }

        private DriveService google_api()
        {
            // Scopes for use with the Google Drive API
            string[] scopes = new string[] { DriveService.Scope.Drive };
            var clientId = "771689808147-82sehat28l1r2651fn0rl2abqhef474m.apps.googleusercontent.com";      // From https://console.developers.google.com
            var clientSecret = "HUfrTwR5SEswbuu0dhKnUKSQ";          // From https://console.developers.google.com
                                                                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            },
            scopes,
            Environment.UserName,
            CancellationToken.None,
            new FileDataStore("Daimto.GoogleDrive.Auth.Store")).Result;
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });
            return service;
        }

        public IList GetFolders()
        {

            IList Files = new List<File>();

            try
            {
                //List all of the files and directories for the current user.  
                // Documentation: https://developers.google.com/drive/v2/reference/files/list
                FilesResource.ListRequest list = this.drive.Files.List();
                list.MaxResults = 150;
                list.Q = "mimeType = 'application/vnd.google-apps.folder'";
                
                FileList filesFeed = list.Execute();

                //// Loop through until we arrive at an empty page
                while (filesFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (File item in filesFeed.Items)
                    {
                        Files.Add(item);
                    }

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }

                    // Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken;

                    // Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex)
            {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);
            }
            return Files;
        }
    }
}
