using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.Mobile.Client.Http;
using Watson.Mobile.Client.Models;
using Watson.Mobile.Client.Options;

namespace Watson.Mobile.Client.Services.Endpoints
{
    public class ChatService
    {
        private readonly HttpClient _httpClient;

        public ChatService(IOptions<ApiSettings> apiSettings)
        {
            var handler = new BypassSslValidationHandler();
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(apiSettings.Value.BaseUrl)
            };            
        }

        public async Task<object> GetChatHistoryAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/chat/messages");
            var json = await response.Content.ReadAsStringAsync();
            Response<object> wrapper = JsonConvert.DeserializeObject<Response<object>>(json);

            return wrapper.Data;
        }
    }
}
