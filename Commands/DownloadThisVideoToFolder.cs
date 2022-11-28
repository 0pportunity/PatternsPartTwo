using CommandPractic;

namespace PatternsPartTwo.Commands
{
    /// <summary>
    /// Команда для вывода информации о видео в консоль.
    /// </summary>
    class DownloadThisVideoToFolder : Command
    {
        YouTubeReceiver receiver;

        public DownloadThisVideoToFolder(YouTubeReceiver receiver)
        {
            this.receiver = receiver;
        }

        // Выполнить
        public override void Run()
        {
            Console.WriteLine("Команда отправлена");
        }

        // Отменить
        public override void Cancel()
        { }
    }
}