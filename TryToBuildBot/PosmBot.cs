using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;

namespace TryToBuildBot
{
    class PosmBot
    {
        public  Telegram.Bot.TelegramBotClient Bot;
        public event Action<Message> OnMessageReceived;
        public event Action<string> LogMessage;
        private readonly string _token = "349066899:AAFiqkKRiwbO8Rgc1bLdANgLqWpbiJvfK3U";
        private const string _baseUrl = "https://api.telegram.org/bot";
        Dictionary<long, Update> updateDictionary ;

        private long _offset = 0;
        public PosmBot()
        {
            updateDictionary = new Dictionary<long, Update>();
        }
        public async void testApiAsync()
        {
            Bot = new Telegram.Bot.TelegramBotClient("349066899:AAFiqkKRiwbO8Rgc1bLdANgLqWpbiJvfK3U");
            var me = await Bot.GetMeAsync();
            System.Console.WriteLine("Hello my name is " + me.FirstName);
            while (true)
            {
                try
                {
                    var updates = await GetUpdatesAsync();
                    foreach (var update in updates)
                    {
                        if (updateDictionary.ContainsKey(update.Message.Chat.Id))
                        {
                            updateDictionary[update.Message.Chat.Id] = update;
                        }
                        else
                        {
                            updateDictionary.Add(update.Message.Chat.Id, update);
                        }
                       
                        
                        _offset = update.Id + 1;
                    }
                    foreach (var key in updateDictionary)
                    {
                        if (key.Value.Message.Text != null && key.Value.Message.Text != String.Empty)
                            Console.WriteLine(updates.Length);
                            OnMessageReceived?.Invoke(key.Value.Message);
                    }
                    updateDictionary = new Dictionary<long, Update>();
                }
                catch (Exception)
                {
                    Thread.Sleep(10000);
                }
            }


        }
        public async Task<T> SendWebRequest<T>(string methodName, Dictionary<string, object> parameters = null)
        {
            var uri = new Uri($"{_baseUrl}{_token}/{methodName}");
            Response<T> responseObject = null;

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response;

                    if (parameters == null || parameters.Count == 0)
                    {
                        response = await client.GetAsync(uri);
                    }
                    else
                    {
                        var data = JsonConvert.SerializeObject(parameters);
                        var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                        response = await client.PostAsync(uri, httpContent);
                    }
                    var resultStr = await response.Content.ReadAsStringAsync();
                    responseObject = JsonConvert.DeserializeObject<Response<T>>(resultStr);
                }
                catch (HttpRequestException e)
                {
                    LogMessage?.Invoke($"Unable to provide operation {methodName}. Exception occured: {e.Message}");
                    throw new HttpRequestException(e.Message);
                }
            }
            return responseObject.Result;
        }
        public async Task<Update[]> GetUpdatesAsync()
        {
            var parameters = new Dictionary<string, object>
            {
                {"offset", _offset},
            };
            return await SendWebRequest<Update[]>("getUpdates", parameters);
        }
    }
}
