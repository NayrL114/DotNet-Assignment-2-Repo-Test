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

        //public static String[] ReadStringArrayFromFile(string path)
        public static List<String> ReadStringListFromFile(string path)
        {
            //return new string[0];
            try
            {
                //string[] lines;
                List<String> lines = new List<String>(); 

                StreamReader fileContent = new StreamReader(path);
                //fileContent.
                //fileContent.

                while (!fileContent.EndOfStream)
                {
                    //string line = fileContent.ReadLine();
                    //lines.Append(fileContent.ReadLine());
                    lines.Add(fileContent.ReadLine());
                }

                fileContent.Close();

                return lines;

                /*string[] lines = System.IO.File.ReadAllLines(path);

                foreach (String line in lines)
                {
                    string[] splits = line.Split(',');
                    //Console.WriteLine
                    foreach (String split in splits)
                    {
                        Console.WriteLine(split);
                    }

                    Console.ReadKey();
                    Console.Clear();
                    return splits;*/
                //}
            }
            catch(FileNotFoundException e)
            {
                // Write the code to Display the error message
                Console.WriteLine(e.Message);
                // Write the code to Read a key from user   
                Console.ReadKey();
                //return new string[0];
                return new List<String>();
            }
            //return new string[0];
            //return new List<String>();
        }// end of: ReadStringListFromFile

        //public static void AppendToFileEnd(string path, List<String> inputDetails)
        public static void AppendToFileEnd(string path, string inputDetails)
        {
            //return new string[0];

            //File.AppendAllLines(path, inputDetails);

            File.AppendAllText(path, inputDetails);

            //try
            //{

            // ADD NEW PATIENT TO THE END OF THE FILE LINE



            //string[] lines;
            //List<String> lines = new List<String>();

            //StreamReader fileContent = new StreamReader(path);
            //fileContent.
            //fileContent.

            /*while (!fileContent.EndOfStream)
            {
                //string line = fileContent.ReadLine();
                //lines.Append(fileContent.ReadLine());
                lines.Add(fileContent.ReadLine());
            }*/

            //return lines;

            /*string[] lines = System.IO.File.ReadAllLines(path);

            foreach (String line in lines)
            {
                string[] splits = line.Split(',');
                //Console.WriteLine
                foreach (String split in splits)
                {
                    Console.WriteLine(split);
                }

                Console.ReadKey();
                Console.Clear();
                return splits;*/
            //}
            /*}
            catch (FileNotFoundException e)
            {
                // Write the code to Display the error message
                Console.WriteLine(e.Message);
                // Write the code to Read a key from user   
                Console.ReadKey();
                //return new string[0];
                //return new List<String>();
            }*/
        }
    }
}
