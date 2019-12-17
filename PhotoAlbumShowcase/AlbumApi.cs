using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PhotoAlbumShowcase.Models;

namespace PhotoAlbumShowcase
{
    public class AlbumApi
    {
        private HttpClient _client;

        public AlbumApi()
        {
            // Configure Client
            _client = new HttpClient { 
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com") 
            };
        }

        public async Task<Photo[]> GetPhotos(int albumId)
        {
            // Get response
            var response = await _client.GetAsync($"/photos?albumId={albumId}");

            // Throw Exception on Failed Request
            response.EnsureSuccessStatusCode();

            // Read response stream to target type
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Photo[]>(responseStream);
        }
    }
}
