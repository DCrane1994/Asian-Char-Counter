using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int docCount = 0;
            int hirCount = 0, katRange = 0, chinRange = 0, chinA = 0, chinB = 0, chinC = 0, chinD = 0, chinE = 0, chinF = 0, nonAsian = 0;
            string line;
            string sourceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
            StreamReader fromFile;

            // Check that there were txt files in the directory
            if (txtFiles.Count() != 0)
            {
                foreach (string currentFile in txtFiles)
                {
                    Console.WriteLine("Currently searching: " + currentFile + "\n");
                    // 932 = SHIFT-JIS
                    using (fromFile = new StreamReader(currentFile, Encoding.GetEncoding(932)))
                    {
                        while ((line = fromFile.ReadLine()) != null)
                        {
                            foreach (char c in line)
                            {
                                // CJK Unified Ideographs range
                                if ((uint)c >= 0x4E00 && (uint)c <= 0x9FEF)
                                {
                                    chinRange++;
                                    count++;
                                    continue;
                                }
                                // Hiragana range
                                if ((uint)c >= 0x3040 && (uint)c <= 0x309F)
                                {
                                    hirCount++;
                                    count++;
                                    continue;
                                }
                                // Katakana range
                                if ((uint)c >= 0x30A0 && (uint)c <= 0x30FF)
                                {
                                    katRange++;
                                    count++;
                                    continue;
                                }
                                // CJK Unified Ideographs Extension A
                                if ((uint)c >= 0x3400 && (uint)c <= 0x4DB5)
                                {
                                    chinA++;
                                    count++;
                                    continue;
                                }
                                // CJK Unified Ideographs Extension B
                                if ((uint)c >= 0x20000 && (uint)c <= 0x2A6D6)
                                {
                                    chinB++;
                                    count++;
                                    continue;
                                }
                                // CJK Unified Ideographs Extension C
                                if ((uint)c >= 0x2A700 && (uint)c <= 0x2B734)
                                {
                                    chinC++;
                                    count++;
                                    continue;
                                }
                                // CJK Unified Ideographs Extension D
                                if ((uint)c >= 0x2B740 && (uint)c <= 0x2B81D)
                                {
                                    chinD++;
                                    count++;
                                    continue;
                                }
                                // CJK Unified Ideographs Extension E
                                if ((uint)c >= 0x2B820 && (uint)c <= 0x2CEA1)
                                {
                                    chinE++;
                                    count++;
                                    continue;
                                }
                                // CJK Unified Ideographs Extension F
                                if ((uint)c >= 0x2CEB0 && (uint)c <= 0x2EBE0)
                                {
                                    chinF++;
                                    count++;
                                    continue;
                                }
                                else
                                {
                                    nonAsian++;
                                    continue;
                                }
                            }
                        }
                        docCount++;
                    }
                }
            }
            // No txt files were found
            else
            {
                Console.WriteLine("Couldn't find any txt files, did you put txt files in this program's directory?");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            Console.WriteLine("Finished checking script.\n" + docCount + " document(s) were checked.");
            Console.WriteLine(count + " Asian characters have been found, NOT INCLUDING punctuation/grammar/numbers.");
            Console.WriteLine(nonAsian + " non-Asian characters were found, INCLUDING punctuation/grammar/numbers.");
            Console.WriteLine("\nAsian characters were distributed across the following ranges: ");
            Console.WriteLine("Hiragana: " + hirCount + "\n" + "Katakana: " + katRange + "\n" + "Kanji: " + chinRange + "\n" + "Kanji Ext A: " + chinA + "\n" + 
                "Kanji Ext B: " + chinB + "\n" + "Kanji Ext C: " + chinC + "\n" + "Kanji Ext D: " + chinD + "\n" + "Kanji Ext E: " + chinE + "\n" + "Kanji Ext F: " + chinF);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            System.Environment.Exit(1);
        }
    }
}
