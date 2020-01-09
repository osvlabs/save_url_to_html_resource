using System;
using System.IO;
using System.Net;

namespace SaveUrlsToFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start....");

            var urls = File.ReadAllText("d:\\urls.txt").Split("\n");
            
            foreach (var url in urls)
            {
                var uri = url.Replace("\r", "");
                var filePath = @"d:/html/" + Path.GetFileName(uri);
                if (Path.GetFileName(uri) != "" && !File.Exists(filePath) ) {
                    try { 
                        WebClient client = new WebClient();
                        client.DownloadFile(uri, filePath);
                        Console.WriteLine(Path.GetFileName(uri));
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            //var url = "https://apph5.yespowering.cn/script/jquery-3.1.0.min.js";


            Console.WriteLine("done");
            Console.ReadLine();
        }



    }
}
