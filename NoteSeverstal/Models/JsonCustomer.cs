using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace NoteSeverstal.Models
{
    internal abstract class JsonCustomer
    {
        public static string JsonFileWay { get; set; }
        public static List<Note> Deserialization(string jsonFile)
        {
            var jsonString = File.ReadAllText(jsonFile);
            var deserializedEmployees = JsonConvert.DeserializeObject<List<Note>>(jsonString);
            return deserializedEmployees;
        }

        public static void Serialization(List<Note> employees, string jsonFile)
        {
            File.WriteAllText(jsonFile, JsonConvert.SerializeObject(employees));
        }

    }
}
