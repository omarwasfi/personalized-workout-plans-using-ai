using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AI.FitMentor.BlazorApp.Services.Interfaces;

namespace AI.FitMentor.BlazorApp.Services.Classes
{
public class HttpService : IHttpService
{
    private HttpClient _httpClient;


        public HttpService(
            HttpClient httpClient

        )
        {
            _httpClient = httpClient;

        }


        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }
        public async Task<T> Post<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            return await sendRequest<T>(request);
        }
        public async Task Post(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            await sendRequest(request);
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        public async Task<T> Put<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            return await sendRequest<T>(request);
        }

        public async Task<T> Delete<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            return await sendRequest<T>(request);
        }
        public async Task Post(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            await sendRequest(request);
        }

        public async Task Put(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            await sendRequest(request);
        }
        
    

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {

            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            
            var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var error = await response.Content.ReadAsStringAsync();
                if (String.IsNullOrEmpty(error))
                {
                    throw new Exception("Unautherized Please Login.");

                }
                throw new Exception(error);

            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
            var result = await response.Content.ReadFromJsonAsync<T>();
            return result;
        }

        private async Task sendRequest(HttpRequestMessage request)
        {

            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
          
            
            var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var error = await response.Content.ReadAsStringAsync();
                if (String.IsNullOrEmpty(error))
                {
                    throw new Exception("Unautherized Please Login.");

                }
                throw new Exception(error);
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
            
        }


}
    
}

