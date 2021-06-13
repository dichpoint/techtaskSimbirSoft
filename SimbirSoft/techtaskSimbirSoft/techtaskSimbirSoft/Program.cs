using System;
using System.Collections.Generic;
using System.Linq;

namespace techtaskSimbirSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ссылку на страницу: ");
            string link = Console.ReadLine();
            string path = "html.txt"; // путь к файлу, в который будет сохраняться html-страница

            string html = DownloadPage.Download(link, path);
            var words = Parser.GetWords(html);

            try
            {
                using (var db = new AppContext())
                {
                    DeleteWords();
                    Display(words);
                    AddWords(words);

                    db.SaveChanges();
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {
                using (var db = new AppContext())
                {
                    db.Database.ExecuteSqlCommand(
                        "CREATE TABLE \"UniqueWords\"(" +
                        "\"id\" INTEGER NOT NULL UNIQUE, " +
                        "\"word\" TEXT NOT NULL UNIQUE, " +
                        "\"count\" INTEGER NOT NULL, " +
                        "PRIMARY KEY(\"id\" AUTOINCREMENT));"
                    );
                    db.SaveChanges();

                    Display(words);
                    AddWords(words);

                    db.SaveChanges();
                    Console.ReadLine();
                }
            }
        }

        private static void DeleteWords()
        {
            using (var db = new AppContext())
            {
                var rows = from o in db.UniqueWords select o;
                foreach (var row in rows)
                {
                    db.UniqueWords.Remove(row);
                }
                db.Database.ExecuteSqlCommand("update sqlite_sequence set seq = 0 WHERE Name = 'UniqueWords'");
                db.SaveChanges();
            }
        }
        private static void AddWords(Dictionary<string, int> dictWords)
        {
            using (var db = new AppContext())
            {
                foreach (var keyValue in dictWords)
                {
                    var word = new UniqueWord(keyValue.Key, keyValue.Value);
                    db.UniqueWords.Add(word);
                }
                db.SaveChanges();
            }
        }
        private static void Display(Dictionary<string, int> dictWords)
        {
            foreach (var keyValue in dictWords)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }
    }
}