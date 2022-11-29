using CommandPractic;

namespace PatternsPartTwo.Commands
{
    /// <summary>
    /// Команда для вывода информации о видео в консоль.
    /// </summary>
    class InfoAboutVideoToConsole : Command
    {
        YouTubeReceiver receiver;
        string urlVideo;

        public InfoAboutVideoToConsole(YouTubeReceiver receiver, string urlVideo)
        {
            this.receiver = receiver;
            this.urlVideo = urlVideo;
        }

        /// <summary>
        /// Вывод информации о видео в консоль
        /// </summary>
        public override async void Run()
        {
            var infoAboutVideo = new Dictionary<string, string>();
            infoAboutVideo = await receiver.GetInfoAsync(urlVideo);
            foreach (var info in infoAboutVideo)
            {
                Console.WriteLine($"{info.Key} : {info.Value}");
            }
        }

        public override void Cancel()
        { }
    }
}