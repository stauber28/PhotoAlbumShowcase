using System;
using System.Threading.Tasks;

namespace PhotoAlbumShowcase
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize helpers
            var albumApi = new AlbumApi();
            var consoleHelper = new ConsoleHelper();

            while (true)
            {
                // Prompt User
                Console.Write("Enter Album Number (ESC to Exit): ");

                // Read Input until Escape or Enter
                var input = consoleHelper.ReadLineOrEscape();

                // Break on Escape
                if (input == null) break;

                // Fetch Results if Integer Input
                if (int.TryParse(input, out int albumId))
                {
                    // Show Loading Text
                    consoleHelper.ShowLoading();

                    // Fetch Photos
                    var photos = await albumApi.GetPhotos(albumId);

                    // Remove Loading Text
                    consoleHelper.ShowLoading(false);

                    // Write Photo Info to Console
                    consoleHelper.WriteAlbum(photos);
                }
                
            }
        }
    }
}
