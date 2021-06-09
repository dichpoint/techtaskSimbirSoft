using System;
using System.Collections.Generic;

namespace techtaskSimbirSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ссылку на страницу: ");
            string link = Console.ReadLine();
            string path = "html.txt"; //путь к файлу, в который будет сохраняться html-страница
            string html = DownloadPage.Download(link, path);

            Display(Parser.GetWords(html));
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