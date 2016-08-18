using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lotto2._0
{
    class Program
    {
        static List<int> Numbers = new List<int>();
        static Random rnd = new Random();
        static string path = "c:\\wyniki.txt";
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.Clear();
                int temp = 0;                                                          
                Console.WriteLine("\nProgram losuje 6 liczb.\n");
                while (Numbers.Count != 6)
                {
                    temp = rnd.Next(1, 50);
                    if (!Numbers.Contains(temp))
                        Numbers.Add(temp);
                }
                Numbers.Sort();
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Plik z wylosowanymi liczbami");
                        sw.WriteLine("\n \n");
                    }
                }
                if (File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write))
                    {

                        for (int i = 0; i < Numbers.Count; i++)
                        {
                            Console.WriteLine(i + 1 + " liczba: " + $"{Numbers[i]}");
                            AddText(fs, $"{Numbers[i]} ");
                        }
                    }
                }                           
                Console.Write("\nWylosować jeszcze raz? (t/n) ");
                choice = Console.ReadLine();
                Numbers.Clear();
            } while ((choice == "t"));
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
     
        
