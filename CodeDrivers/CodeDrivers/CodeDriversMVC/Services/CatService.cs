
using System.Text.Json;

namespace CodeDriversMVC.Services
{
    public class CatService
    {
        public static async Task<CatFunFact> GetCatFunFactAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://catfact.ninja/fact");
            //request.Headers.Add("Cookie", "XSRF-TOKEN=eyJpdiI6IlprYTZoblVTTGNWZ01TTWhUeWhhY1E9PSIsInZhbHVlIjoiM1BHZnZyaEZKTFBvUEpPTGtUeThuMFNJNnZQUmw2MHVqdVFYTEdVVlM5Unh3MmlySE4za1RzQWlLZkpsU3ByZGprN1R1enBkSkxGMTUxTndpT3g5RWU0bUZLR2pYRktyUW0xQlQvcXVuaEpBa3k3M21uQnRDNjVUWVpvWnRvNjAiLCJtYWMiOiJhZDYzN2Y0YjY1YzI5ZTUyZGYzZjk2ZDllZWJkOTNkN2RiNjFiMDhiZTg5OWYwNTA3MjE0NTI5NzJjODFlNzk5IiwidGFnIjoiIn0%3D; catfacts_session=eyJpdiI6IklkZzNvd010bXFia1lrYXFjSXhLcVE9PSIsInZhbHVlIjoiSlE3Vnc4bVhIWGlnMDFXdDJaTC9ZQzRuQTZpa25UaDg0WFFoLzQzd0ZpaGIzaHN1NG04YkFYVXpNcVZHbDV4d2RBRXdhdjRBeUprVFBvdDZHRXcvMzA3dTNCd1AzUzFIUVhlUlIzMm1kTkFmM3JpYzNrUlhmUUFHYTZ0OGtPM0siLCJtYWMiOiI0ZmMwYTQ4ZTI1Zjc1YjRmMGFiOTQzZGRiNzY0ZjQxMjVhMThkODkyN2QyNTVjMzAyNzA5YmZjNjc2OGE2NGZkIiwidGFnIjoiIn0%3D");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return await JsonSerializer.DeserializeAsync<CatFunFact>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }

    public class CatFunFact
    {
        public string Fact { get; set; }
        public int Length { get; set; }
    }
}
