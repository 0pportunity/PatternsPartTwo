using CommandPractic;

namespace PatternsPartTwo.Commands
{
    /// <summary>
    /// Команда для вывода информации о видео в консоль.
    /// </summary>
    class DownloadThisVideoToFolder : Command
    {
        YouTubeReceiver receiver;
        string pathToDownload;
        string videoUrl;

        public DownloadThisVideoToFolder(YouTubeReceiver receiver, string videoUrl, string pathToDownload)
        {
            this.receiver = receiver;
            this.videoUrl = videoUrl;
            this.pathToDownload = pathToDownload;
        }

        /// <summary>
        /// Загрузка видео в указанную папку
        /// </summary>
        public override void Run()
        {
            Console.WriteLine("Начало загрузки...");
            receiver.Download(videoUrl, pathToDownload);
            Console.WriteLine("Загрузка завершена");
        }

        public override void Cancel()
        { }
    }
}