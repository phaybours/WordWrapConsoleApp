using System;
using System.Collections.Generic;
using System.IO;

namespace WordWrapConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Begining:
            Console.WriteLine("Hit Enter to coninue or input 'X' to quit");
            string quit = Console.ReadLine();
            int invalidaInputCount = 0;
            while (!string.Equals(quit, "x", StringComparison.InvariantCultureIgnoreCase))
            {
            EnterOption:
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Read string from file.");
                Console.WriteLine("2. Enter input string.");

                int option;
                _ = int.TryParse(Console.ReadLine(), out option);
                if (option == 1)
                {
                    Console.WriteLine(@"Enter input file path (e.g. C:\Users\Folder\inputfile.txt): ");
                    string inputPath = Console.ReadLine();

                    Console.WriteLine(@"Enter output file path (e.g. C:\Users\Folder\outputfile.txt): ");
                    string outputPath = Console.ReadLine();

                    Console.WriteLine("Enter lenth per line");
                    int length = int.Parse(Console.ReadLine());
                    WrapSentence(inputPath, outputPath, length);
                }
                else if (option == 2)
                {
                    Console.WriteLine(@"Enter sentence: ");
                    string input = Console.ReadLine();

                    Console.WriteLine("Enter lenth per line");
                    int length = int.Parse(Console.ReadLine());
                    WrapSentence(input, length);
                }
                else
                {
                    invalidaInputCount++;
                    if (invalidaInputCount == 3)
                        goto Begining;

                    Console.WriteLine("Please seleect a valid option");
                    Console.WriteLine();
                    goto EnterOption;
                }

                goto Begining;
            }
        }

        private static void WrapSentence(string inputFilePath, string outputFilePath, int length)
        {
            try
            {
                string line;
                using (var fs = File.OpenRead(inputFilePath))
                using (var fw = File.OpenWrite(outputFilePath))
                using (var sw = new StreamWriter(fw))
                using (var reader = new StreamReader(fs))
                    while ((line = reader.ReadLine()) != null)
                    {
                        var result = line.SplitTheSentenceAtWord(length);
                        foreach (var word in result)
                        {
                            sw.WriteLine(word);
                        }
                        sw.WriteLine("-----------------------------------------");
                    }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        private static void WrapSentence(string input, int length)
        {
            try
            {
                foreach (var word in input.SplitTheSentenceAtWord(length))
                {
                    Console.WriteLine(word);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }


    }
}
