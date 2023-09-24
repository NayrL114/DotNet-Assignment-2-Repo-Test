using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        public static List<string> ReadStringListFromFile(string path)
        {
            //return new string[0];
            try
            {
                //string[] lines;
                List<string> lines = new List<string>(); 

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
                return new List<string>();
            }
            //return new string[0];
            //return new List<String>();
        }// end of: ReadStringListFromFile

        public static void AppendAtTheEndOfLine(string path, string targetID, string updateContent)
        {
            //File.Move(path, path, )
            //File.Replace

            try
            {
                /*//StreamWriter fileContent = new StreamWriter(path);
                FileStream fileContent = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                //StreamReader fileReading = new StreamReader(path);

                for (int i = 0; i < fileContent.Length; i++)
                {
                    //string content = fileReading.ReadLine;
                    //while (fileContent.R != "\n") ;

                }

                //fileContent.Write(updateContent);*/

                string fullContents = File.ReadAllText(path);

                //List<string> contents = fullContents.Split('\n');
                string[] contents = fullContents.Split("\n");
                // Breaking down full file content into line by line content details with comma,

                for (int i = 0; i < contents.Length; i++)
                {
                    //List<string> details = contents[i].Split(",");

                    if (contents[i] == "")
                    {
                        continue;
                    }

                    string[] details = contents[i].Split(",");
                    // Breaking down full file content into user attributes seperated by comma,
                    /*for (int i = 0; i < details.Length; i++)
                    {
                        if (details[1] == targetID)
                        {

                        }
                    }*/

                    //Console.WriteLine(details.Length);   

                    if (details[4] == targetID)
                    /*if (details[1] == targetID)*/ // details[1] should be the ID attribute for all users. 
                    {
                        //Console.WriteLine("Found correct user with ID: {0}", targetID);
                        details[details.Length - 1] = updateContent;

                        /*Console.WriteLine("Displaying stuff in details array, after updating stuff");
                        foreach (string line in contents)
                        {
                            Console.WriteLine(line);
                        }*/

                        string updatedLine = "";
                        for (int a = 0; a < details.Length; a++)
                        {
                            updatedLine += details[a];
                            updatedLine += ",";
                        }

                        contents[i] = updatedLine;

                        /*Console.WriteLine("Displaying updated stuff in contents array");
                        foreach(string line in contents) 
                        {
                            Console.WriteLine(line);
                        }*/

                        break;
                    }
                }// end of: for loop

                // This should overwrite the updated text back to the original file
                // It will firstly delete the original file, 
                // Then create a new file with updated contents, along with original unchanged contents.

                //contents.R
                /*List<string> contentsTrimmed = new List<string>();
                foreach (string line in contents)
                {
                    contentsTrimmed.Add(line);
                }
                contentsTrimmed.RemoveAll("\r");*/
                //contentsTrimmed.R

                File.Delete(path);

                /*foreach (string line in contents)
                {
                    File.AppendAllText(path, line);
                }*/

                for (int i = 0; i < contents.Length; i++)
                {                    
                    if (i != contents.Length - 1)
                    {
                        contents[i] += "\n";
                    }
                    File.AppendAllText(path, contents[i]);
                }
                //contents.Remove(contents.Length);   
                //File.WriteAllLines(path, contents);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //public static void AppendToFileEnd(string path, List<String> inputDetails)
        public static void AppendToFileEnd(string path, string inputDetails)
        {
            //return new string[0];

            //File.AppendAllLines(path, inputDetails);

            File.AppendAllText(path, inputDetails);

            

            /*File.WriteAllText();*/

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
