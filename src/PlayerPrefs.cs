using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InscryptionTextureConverter
{
    public static class PlayerPrefs
    {
        private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "save.json");
        
        public static Dictionary<string, object> data = new Dictionary<string, object>();

        public static string GetString(string key, string defaultValue=null)
        {
            if (data.TryGetValue(key, out object d))
            {
                return (string)d;
            }

            return defaultValue;
        }

        public static void SetString(string key, string value)
        {
            data[key] = value;
            Save();
        }

        public static void Load()
        {
            if (!File.Exists(FilePath))
            {
                data = new Dictionary<string, object>();
                return;
            }
            
            string text = File.ReadAllText(FilePath);
            if (string.IsNullOrEmpty(text))
            {
                data = new Dictionary<string, object>();
            }
            else
            {
                Dictionary<string, object>? json = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
                if (json == null)
                {
                    data = new Dictionary<string, object>();
                }
                else
                {
                    data = json;
                }
            }
        }

        public static void Save()
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}