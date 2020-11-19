using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Guestbook.Classes
{
    class SerializeDeserialize
    {
        // Create filepath
        public string filePath = @"C:\Users\emmel\source\repos\Guestbook\Guestbook\posts.json";

        public void Serialize(string getJson, List<GuestbookPosts> list)
        {
            // Take json and serialize and write tp file
            getJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, getJson);
        }

        public void DeSerialize(out string getJson, out List<GuestbookPosts> list)
        {
            // Get json and deserialize or create new list
            getJson = File.ReadAllText(filePath);
            var postlist = JsonConvert.DeserializeObject<List<GuestbookPosts>>(getJson) ?? new List<GuestbookPosts>();
            list= postlist;
        }
    }
}
