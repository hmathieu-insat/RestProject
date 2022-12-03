// See https://aka.ms/new-console-template for more information

namespace RestProject.Client
{
    class HttpRequester
    {
        private readonly HttpClient _client;
        public HttpRequester(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetAsync(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string endpoint, string content)
        {
            var response = await _client.PostAsync(endpoint, new StringContent(content));
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PutAsync(string endpoint, string content)
        {
            var response = await _client.PutAsync(endpoint, new StringContent(content));
            return await response.Content.ReadAsStringAsync();
        }
    }
}