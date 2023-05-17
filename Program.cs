using System;
using System.IO;

// Copyright (c) 2023 Cod3xDev. All rights reserved.

namespace JsonSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: JsonSearch <searchDirectory> <searchString>");
                return;
            }

            string searchDirectory = args[0];
            string searchString = args[1];
            string searchPattern = "*.json";

            SearchJsonFiles(searchDirectory, searchPattern, searchString);
        }

        static void SearchJsonFiles(string directory, string searchPattern, string searchString)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories))
                {
                    try
                    {
                        string content = File.ReadAllText(file);
                        if (content.Contains(searchString))
                        {
                            Console.WriteLine($"{searchString} found in {file}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading {file}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching {directory}: {ex.Message}");
            }
        }
    }
}