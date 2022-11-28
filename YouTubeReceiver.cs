using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace CommandPractic
{
    /// <summary>
    /// Адресат команды
    /// </summary>
    public class YouTubeReceiver
    {
        /// <summary>
        /// Возвращает информацию о видео.
        /// </summary>
        /// <param name="videoUrl"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> GetInfoAsync(string videoUrl)
        {
            var youtube = new YoutubeClient();
            try
            {
                var video = await youtube.Videos.GetAsync(videoUrl);

                Dictionary<string, string> InfoList = new Dictionary<string, string>()
                {
                    {"Название", video.Title},
                    {"Дата загрузки", video.UploadDate.ToString()},
                    {"Продолжительность", video.Duration.ToString()},
                    {"Описание", video.Description}
                };
                return InfoList;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Dictionary<string, string> DefaultList = new Dictionary<string, string>()
                {
                    {"Ошибка", "Данные не получены"}
                };
                return DefaultList;
            }
        }

        /// <summary>
        /// Метод для загрузки видео
        /// </summary>
        public async Task Download(string videoUrl, string pathToDownload)
        {
            var youtube = new YoutubeClient();
            try
            {
                var video = await youtube.Videos.GetAsync(videoUrl);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
                var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
                await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath: $"{pathToDownload}/{video.Title.Replace(".", "_")}.{streamInfo.Container}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}