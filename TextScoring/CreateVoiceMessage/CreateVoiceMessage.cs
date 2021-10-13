using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;
using System.Configuration;
using System.Threading.Tasks;
namespace TextScoring.CreateVoiceMessage
{
    /// <summary>
    /// Создание голосового сообщения
    /// </summary>
    public class CreateVoiceMessage
    {
        private static string AWSAccessKeyId { get; } = ConfigurationManager.AppSettings.Get("AWSAccessKeyId");
        private static string AWSSecretKey { get; } = ConfigurationManager.AppSettings.Get("AWSSecretKey");

        /// <summary>
        /// Создает голосовое сообщение
        /// </summary>
        static public async Task<bool> CreateMessage(string message)
        {
            // указываем данные используемого аккаунта
            BasicAWSCredentials awsCredentials =
                new BasicAWSCredentials(AWSAccessKeyId, AWSSecretKey);

            // создаём объект класса AmazonPollyClient, 
            // передавая данные аккаунта и указывая используемый регион
            AmazonPollyClient amazonPollyClient =
                new AmazonPollyClient(awsCredentials, RegionEndpoint.EUCentral1);
            // создаём объект запроса
            SynthesizeSpeechRequest synthesizeSpeechRequest = MakeSynthesizeSpeechRequest(ProcessTextMessage.TruncateString(message));
            // получаем ответ от AWS Polly
            SynthesizeSpeechResponse synthesizeSpeechResponse =
                await amazonPollyClient.SynthesizeSpeechAsync(synthesizeSpeechRequest);

            return CreateOggFile.CreateFile(synthesizeSpeechResponse.AudioStream);
        }

        /// <summary>
        /// Создание и озвучивание текста
        /// </summary>
        private static SynthesizeSpeechRequest MakeSynthesizeSpeechRequest(string message)
        {
            SynthesizeSpeechRequest synthesizeSpeechRequest = new SynthesizeSpeechRequest();
            synthesizeSpeechRequest.Text = message;
            // определяем язык
            synthesizeSpeechRequest.LanguageCode = LanguageCode.RuRU;
            synthesizeSpeechRequest.OutputFormat = OutputFormat.Ogg_vorbis;
            // указываем желаемый голос
            synthesizeSpeechRequest.VoiceId = VoiceId.Maxim;

            return synthesizeSpeechRequest;
        }
    }
}
