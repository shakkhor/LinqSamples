using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowFilesWithoutLinq(path);
            Console.WriteLine("**********");
            ShowFilesWitLinq(path);
            Console.WriteLine("Press any key");
            Console.ReadKey();

            
        }

        private static void ShowFilesWitLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            foreach(var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length}");
            }
        }

        private static void ShowFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for(int i =0; i<5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-20} : {file.Length}");
            }
        }
        
    }
    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
