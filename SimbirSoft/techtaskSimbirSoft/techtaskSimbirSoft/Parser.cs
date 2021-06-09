using System;
using System.Collections.Generic;
using System.Linq;

namespace techtaskSimbirSoft
{
    class Parser
    {
        public static Dictionary<string, int> GetWords(string html)
        {
            string text = "";
            int i = html.IndexOf("<body");
            int end = html.IndexOf("<script>");
            end = end == -1 ? html.IndexOf("</body>") : end;

            for (; i < end; i++)
            {
                if (html[i] == '<')
                {
                    while (html[i] != '>')
                        i++;
                    if (html[i] == '<')
                        text += "*";
                }
                else
                    text += html[i];
            }

            char[] sep = { ' ', ',', ';', ':', '—', '-', '‑',
                '.', '.', '·', '!', '?', '"', '«', '»', '*',
                '(', ')', '\n', '\r', '\t', '\\', '[', ']',
                '/', '©', '+', '=', '&' };

            string[] words = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            return GetUniqueWords(words);
        }

        private static Dictionary<string, int> GetUniqueWords(string[] s)
        {
            List<string> uniqueWords = new List<string>();
            var dict = new Dictionary<string, int>();
            uniqueWords = s.Distinct().ToList();

            foreach (var x in uniqueWords)
            {
                dict[x] = s.Count(w => (w == x));
            }

            return dict;
        }        

    }
}