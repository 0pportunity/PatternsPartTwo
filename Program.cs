using CommandPractic;
using PatternsPartTwo.Commands;
using System.Text;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // создадим отправителя 
        var sender = new Sender();

        // создадим получателя 
        var receiver = new YouTubeReceiver();

        bool needCancel; // условие для входа в блок инициализации команды
        Command command; // переменная команды

        Console.WriteLine("Начало работы. Следуйте инструкциям программы.");
        Console.WriteLine("\n\n\nВведите ссылку на видео с YouTube:\n\n\n");
        string videoUrl = Console.ReadLine();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("\n\n\nВыберите действие:" +
                $"\n\tдля просмотра информации введите 1" +
                $"\n\tдля скачивания видео введите 2" +
                $"\n\tвыбрать другое видео - введите 3" +
                "\n\n\n"); ;
            string textCommand = Console.ReadLine();

            switch (textCommand)
            {
                case "1":
                    needCancel = false;
                    command = new InfoAboutVideoToConsole(receiver, videoUrl);
                    break;

                case "2":
                    needCancel = false;
                    Console.WriteLine("\n\n\nВведите путь для загрузки:\n\n\n");
                    string pathToDownload = Console.ReadLine();
                    command = new DownloadThisVideoToFolder(receiver, videoUrl, pathToDownload);
                    break;

                case "3":
                    needCancel = true;
                    Console.WriteLine("\n\n\nВведите ссылку на видео с YouTube:\n\n\n");
                    videoUrl = Console.ReadLine();
                    command = null; // ссылка будет присвоена при следующей итерации цикла
                    break;

                default:
                    needCancel = true;
                    command = null;
                    break;
            }

            if (needCancel == false)
            {
                // инициализация команды
                sender.SetCommand(command);

                //  выполнение
                sender.Run();
            }
        }
    }
}