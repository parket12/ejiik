﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using WindowChromeExample;

namespace ejiiik
{
    public class Note
    {
        public static string jsonpath = "C:/gap/datochka.json";

        public string name;
        public string text;
        public string date;
        public Note(string NoteName, string NoteText, string NoteDate)
        {
            this.name = NoteName;
            this.text = NoteText;
            this.date = NoteDate;
        }

        static public void SaveToFile<T>(T list, string path)
        {
            if (!System.IO.File.Exists(jsonpath))
            {
                Directory.CreateDirectory("C:/gap/");
                FileStream fileStream = System.IO.File.Create(jsonpath);
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(list);
            System.IO.File.WriteAllText(jsonpath, json);
        }

        static public List<T> ReadFromFile<T>(string path)
        {
            List<T> result;

            if (!File.Exists(jsonpath))
            {
                Directory.CreateDirectory("C:/gap/");
                FileStream fileStream = System.IO.File.Create(jsonpath);
                fileStream.Dispose();
            }

            string resultInfo = System.IO.File.ReadAllText(jsonpath);
            result = JsonConvert.DeserializeObject<List<T>>(resultInfo);

            return result;
        }
    }
}