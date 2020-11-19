using System;
using System.Collections.Generic;
namespace Guestbook.Classes
{
    class Delete
    {
        // Create variable
        string idInput;
        public string filePath = @"C:\Users\emmel\source\repos\Guestbook\Guestbook\posts.json";

        // Instansiate class and 
        SerializeDeserialize serialize = new SerializeDeserialize();

        public void Remove()
        {
            // Deserialize and write all post
            serialize.DeSerialize(out string getJson, out List<GuestbookPosts> list);
            int i = 0;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var post in list)
            {
                Console.WriteLine($"{i} - {post.name}, {post.post} \n");
                i++;
            }

            // Write message and take input
            Console.WriteLine("Ange nummret på det inlägg du vill radera.");
            idInput = Console.ReadLine();

            // try catch to try and delete and catch if something goes wrong
            try
            {
                // Convert to int, delete the right post and save the list again
                int id = Convert.ToInt32(idInput);
                list.RemoveAt(id);
                serialize.Serialize(getJson, list);
                Console.Clear();

            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentOutOfRangeException)
            {
                // Write a error message and go to top
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Raderingen misslyckades, försök igen...");
                Remove();
            }
        }

    }
}
