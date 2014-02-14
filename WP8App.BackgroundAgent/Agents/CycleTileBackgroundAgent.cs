using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Phone.Shell;

namespace WPAppStudio.BackgroundProcess.Agents
{
    public class CycleTileAgent
    {
        public const string LiveTileFolder = "/shared/shellcontent/";

        private List<Task> _downloadTasks; 

        public void UpdateCycleTile(IEnumerable<string> newImagesFiles)
        {
            _downloadTasks = new List<Task>();
            var filesReplacements=GetFilesReplacement(newImagesFiles);
            if(filesReplacements.Count>0)
            {
                DownloadFiles(filesReplacements);
                Task.WaitAll(_downloadTasks.ToArray(), 20000);
            }
            CreateCycleData();
        }

        public Dictionary<string, string> GetFilesReplacement(IEnumerable<string> newImagesFiles)
        {
            var fileReplacements = new Dictionary<string, string>();
            var purgePosition = new Random();
            List<string> currentTileFiles;
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStore.DirectoryExists(LiveTileFolder))
                    isoStore.CreateDirectory(LiveTileFolder);

                currentTileFiles = isoStore.GetFileNames(LiveTileFolder)
                        .Select(Path.GetFileName)
                        .ToList();
            }
            foreach (var newImageFile in newImagesFiles)
            {
                if (currentTileFiles.Contains(Path.GetFileName(newImageFile)))
                    currentTileFiles.Remove(Path.GetFileName(newImageFile));
                else
                {
                    var firstOldFile = currentTileFiles.Count > 0
                        ? currentTileFiles[purgePosition.Next(0, currentTileFiles.Count - 1)]
                        : null;
                    fileReplacements.Add(newImageFile, firstOldFile);
                    currentTileFiles.Remove(firstOldFile);
                }
            }
            return fileReplacements;
        }

        public void DownloadFiles(Dictionary<string, string> filesReplacement)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStore.DirectoryExists(LiveTileFolder))
                    isoStore.CreateDirectory(LiveTileFolder);
            }
			
			//Remove old images in LiveTileFolder
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string[] oldImages = isoStore.GetFileNames(LiveTileFolder);
                foreach (string oldImage in oldImages)
                    isoStore.DeleteFile(oldImage);
            }
			
            foreach (var item in filesReplacement.Keys)
            {
                var transferUri = new Uri(Uri.EscapeUriString(item), UriKind.RelativeOrAbsolute);
                var localUri = new Uri(LiveTileFolder + Path.GetFileName(item), UriKind.RelativeOrAbsolute);
                 
                var request = WebRequest.CreateHttp(transferUri);
                _downloadTasks.Add(Task.Factory.StartNew(() => DownloadFile(request, localUri)));
            }
        }

        private static void DownloadFile(HttpWebRequest request, Uri localUri)
        {
            var response = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse,
                null);
            response.Wait();
            using (var responseStream = response.Result.GetResponseStream())
            {
                using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var isoStoreFile = isoStore.OpenFile(localUri.ToString(),
                        FileMode.Create,
                        FileAccess.ReadWrite))
                    {
                        var dataBuffer = new byte[1024];
                        while (responseStream.Read(dataBuffer, 0, dataBuffer.Length) > 0)
                        {
                            isoStoreFile.Write(dataBuffer, 0, dataBuffer.Length);
                        }
                    }
                }
            }
        }

        public void CreateCycleData()
        {
            IEnumerable<Uri> images;
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                images = isoStore.GetFileNames(LiveTileFolder).Take(9).Select(
                        k => new Uri("isostore:" + LiveTileFolder + Path.GetFileName(k), UriKind.Absolute));
            }
            var cycleTile = new CycleTileData()
            {
                CycleImages = images
            };
			
            ShellTile.ActiveTiles
                .First()
                .Update(cycleTile);
        }
    }
}