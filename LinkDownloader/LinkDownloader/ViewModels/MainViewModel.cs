using ReactiveUI;
using System.Net;
using System.Reactive;
using System.Diagnostics;
using System.IO;
using System;

namespace LinkDownloader.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            DownloadButton = ReactiveCommand.Create(() =>
            {
                string remoteUri = "http://www.contoso.com/library/homepage/images/";
                string fileName = "ms-banner.gif", myStringWebResource = null;
                // Create a new WebClient instance.
                WebClient myWebClient = new WebClient();
                // Concatenate the domain with the Web resource filename.
                myStringWebResource = remoteUri + fileName;
                Debug.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
                // Download the Web resource and save it into the current filesystem folder.
                try
                {
                    myWebClient.DownloadFile(myStringWebResource, fileName);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Ошибка скачивания файла + {e}");
                }
                Debug.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
                Debug.WriteLine("Downloaded file saved in the following file system folder:\n\t" + Directory.GetCurrentDirectory());
            });
        }
        public ReactiveCommand<Unit, Unit> DownloadButton { get; set; }

        public string EnterLink => "Введите ссылку";
        public string Link => "http://www.contoso.com/library/homepage/images/";
        public string EnterEpisodes => "Введите количество серий";
        public string NumberOfEpisodes => "12";
        public string Download => "Загрузить";
    }
}
