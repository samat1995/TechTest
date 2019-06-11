using AutomationTests.Types;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutomationTests.Services
{
    public class JsonPlaceholderService
    {
        private JsonApiService _apiService;

        public JsonPlaceholderService()
        {
            _apiService = new JsonApiService();
        }

        public Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return _apiService.GetAsync<IEnumerable<Post>>("posts");
        }

        public Task<IEnumerable<Comment>> GetAllCommentsAsync(int postId)
        {
            return _apiService.GetAsync<IEnumerable<Comment>>($"posts/{postId}/comments");
        }

        public Task<Post> GetPostAsync(int postId)
        {
            return _apiService.GetAsync<Post>($"posts/{postId}");
        }

        public async Task<Post> CreatePost<T>(T post)
        {
            var response = await _apiService.PostAsync("posts", post);
            return JsonConvert.DeserializeObject<Post>(await response.Content.ReadAsStringAsync());
        }

        public Task<HttpResponseMessage> DeletePost(int postId)
        {
            return _apiService.DeleteAsync($"posts/{postId}");
        }
    }
}
