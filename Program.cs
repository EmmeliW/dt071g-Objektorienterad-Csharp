using System;
using System.Collections.Generic;
using System.Threading;
using Guestbook.Classes;

namespace Guestbook
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Create variables
            string name;
            string guestPost;

            // Instansiate class
            SerializeDeserialize serialize = new SerializeDeserialize();
            Add add = new Add();
            Delete delete = new Delete();

            // Create bool
            bool showChoices = true;

            // Do while to loop the menu and choises
            do
            {
                // Vrite out menu and take input
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("En liten gästbok \n \n" +
                    "Om du vill lägga till ett inlägg, skriv 1\n" +
                    "Om du vill radera ett inlägg, skriv 2 \n" +
                    "Om du vill avsluta. skriv 3" +
                    "\n");
                string num = Console.ReadLine();

                // Post all the posts in the guestbook
                serialize.DeSerialize(out string getJson, out List<GuestbookPosts> list);
                int i = 0;
                foreach (var post in list)
                {
                    Console.WriteLine($"{i} - {post.name}, {post.post} \n");
                    i++;
                }

                // If statment to check input value
                if (num == "1")
                {
                    // Do While name or input in empty
                    do
                    {
                        // Take input
                        Console.Clear();
                        Console.WriteLine("Var noga med att inte lämna något tomt. =)");
                        Console.WriteLine("Skriv in din signatur");
                        name = Console.ReadLine();
                        Console.WriteLine("Skriv in ditt inlägg");
                        guestPost = Console.ReadLine();
                    }

                    while (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(guestPost));

                    // Run Create method in add class
                    add.Create(name, guestPost);

                    // Clear console, write message and go to menu again
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Ditt inlägg är tillagt");
                    showChoices = true;
                }
                else if (num == "2")
                {
                    // Run remove methos fron delete class and write message
                    Console.Clear();
                    delete.Remove();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inlägget är raderat");
                }
                else if (num == "3")
                {
                    // Write massage and close app
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Tack för idag");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                }
                else
                {
                    // Write message and go to top of loop
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste välja någon av alternativen jag gav dig.");
                    showChoices = true;

                }
            }
            while (showChoices);            
        }
    }
}
