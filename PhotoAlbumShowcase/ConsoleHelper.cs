using PhotoAlbumShowcase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbumShowcase
{
    internal class ConsoleHelper
    {
        // Photo Information Template
        private readonly string _template = @"[{0}] {1}";
        public void WriteAlbum(Photo[] photos)
        {   
            if (photos.Length > 0)
            {
                foreach (var photo in photos)
                {
                    // Fill Template and Write to Console
                    Console.WriteLine(string.Format(_template,
                        photo.Id,
                        photo.Title));
                }
            }
            else {
                Console.WriteLine("Album is Empty");
            }

            Console.WriteLine();
        }

        public void ShowLoading(bool show = true)
        {
            if (show)
            {
                Console.Write("Loading...");
            }
            else
            {
                // Naive Clearing of Loading Text
                var pos = Console.CursorLeft;

                Console.CursorLeft = 0;
                Console.Write(new String(' ', 10));
                Console.CursorLeft = 0;
            }
        }

        public string ReadLineOrEscape()
        {
            string result = null;

            StringBuilder buffer = new StringBuilder();

            ConsoleKeyInfo info = Console.ReadKey(true);

            //Store User Input until Escape or Enter
            while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
            {
                Console.Write(info.KeyChar);
                buffer.Append(info.KeyChar);
                info = Console.ReadKey(true);
            }

            if (info.Key == ConsoleKey.Enter)
            {
                // Writes buffer content or string.Empty 
                result = buffer.ToString();
            }

            //Move to New Line
            Console.WriteLine();

            return result;
        }
    }
}
