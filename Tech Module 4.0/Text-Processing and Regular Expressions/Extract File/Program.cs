using System;

namespace Extract_File
{
    class Programs
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int startIndexofFile = path.LastIndexOf("\\") + 1;
            string file = path.Substring(startIndexofFile);
            int startIndexOfExtension = path.LastIndexOf('.') + 1;
            string extension = path.Substring(startIndexOfExtension);
            int extensionAtFile = file.IndexOf('.');

            file = file.Remove(extensionAtFile);
            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
