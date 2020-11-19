using System;
using System.Collections.Generic;
namespace Guestbook.Classes
{
    public class Add
    {
        // Instansiate class
        SerializeDeserialize serialize = new SerializeDeserialize();
        GuestbookPosts guestbookPosts = new GuestbookPosts();
        public string filePath = @"C:\Users\emmel\source\repos\Guestbook\Guestbook\posts.json";

        public void Create(string name, string post) 
        {
            Console.Clear();
            // Run method deserialize
            serialize.DeSerialize(out string getJson, out List<GuestbookPosts> list);

            // Add new post
            list.Add(new GuestbookPosts()
            {
                name = name,
                post = post,
            });
            // Run method serialize
            serialize.Serialize(getJson, list);
        }
    }
}
