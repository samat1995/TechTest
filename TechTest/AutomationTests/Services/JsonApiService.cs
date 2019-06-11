using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace AutomationTests.Services
{
    public class JsonApiService
    {
        private HttpClient _client;

        public JsonApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _client.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var serialisedResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(serialisedResponse);
            }
            throw new HttpRequestException($"Unexpected response status code: {response.StatusCode}");
        }

        public Task<HttpResponseMessage> PostAsync<T>(string uri, T body)
        {
            string serialisedBody = JsonConvert.SerializeObject(body);
            return _client.PostAsync(uri, new StringContent(serialisedBody));
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            return _client.DeleteAsync(uri);
        }


    }
}
