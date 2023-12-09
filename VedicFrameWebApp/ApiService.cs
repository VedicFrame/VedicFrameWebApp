namespace VedicFrameWebApp
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://localhost:7006/"); // Replace with your API base URL
        }

        public async Task<string> GetApiDataAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7006/api/Books"); // Replace with your API endpoint
            response.EnsureSuccessStatusCode();


            // return result;

            return await response.Content.ReadAsStringAsync();
        }
    }   
}
