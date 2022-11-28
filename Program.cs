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

        // создадим команду 
        var commandOne = new DownloadThisVideoToFolder(receiver);
        var url = Console.ReadLine();
        var commandTwo = new InfoAboutVideoToConsole(receiver, url);

        // инициализация команды
        sender.SetCommand(commandTwo);

        //  выполнение
        sender.Run();
        Console.ReadKey();
    }
}

namespace CommandPractic
{

    /// <summary>
    /// Отправитель команды
    /// </summary>
    class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        // Выполнить
        public void Run()
        {
            _command.Run();
        }

        // Отменить
        public void Cancel()
        {
            _command.Cancel();
        }
    }
}