using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CsvReader
{
    internal static class Program
    {
        private static void Main()
        {
            var lines = File.ReadAllLines(@"content\MOCK_DATA.csv");
            var people = new List<Person>();
            foreach (var line in lines)
            {
                var x = line.Split(',');
                var person = new Person()
                {
                    Id = Convert.ToInt32(x[0]),
                    FirstName = x[1],
                    LastName = x[2],
                    Email = x[3],
                    Gender = x[4],
                    IpAddress = x[5]
                };
                people.Add(person);
                Console.WriteLine(JsonConvert.SerializeObject(person, new JsonSerializerSettings{ NullValueHandling = NullValueHandling.Include, Formatting = Formatting.Indented }));
            }

            Console.WriteLine($"{people.Count} entries processed.");
        }
    }
}
