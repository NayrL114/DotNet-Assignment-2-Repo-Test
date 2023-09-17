using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileManager
    {

        public static void ReadFromFile(string path)
        {
            if (File.Exists(path)) { }
        }

        public static void WriteToFile(string path)
        {
            if (File.Exists(path)) { }
        }

        public static String[] ReadStringArrayFromFile(string path)
        {
            return new string[0];
        }
    }
}
