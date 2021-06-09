using System;
using System.Net;
using System.IO;

namespace techtaskSimbirSoft
{
    public class DownloadPage
    {
        public static string Download(string link, string path)
        {
            string textPade = "";

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(link, path);
                }

                using (StreamReader str = new StreamReader(path))
                {
                    textPade = str.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return textPade;
        }
    }
}