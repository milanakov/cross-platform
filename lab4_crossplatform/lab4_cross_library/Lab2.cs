using System;
using System.Collections.Generic;
using System.IO;

namespace lab4_cross_library
{
    public class Lab2
    {
        public void RunLab2(string input_File, string output_File)
        {
            int[] directionIndices = new int[1 + 'Z'];
            for (int i = 0; i < directionIndices.Length; i++)
            {
                directionIndices[i] = -1;
            }

            List<int[]> characterCounts = new List<int[]>();
            List<int[]> resultCount = new List<int[]>();
            char[] validCharacters = new char[] { 'N', 'S', 'W', 'E', 'U', 'D' };

            // зіставдення символів з відповідними індексами в масиві directions
            for (int i = 0; i < validCharacters.Length; i++)
            {
                directionIndices[validCharacters[i]] = i;
            }
            
            for (int i = 0; i < validCharacters.Length; i++)
            {
                characterCounts.Add(new int[validCharacters.Length]);
            }
            
            using (StreamReader inputFile = new StreamReader(input_File))
            {
                using (StreamWriter outputFile = new StreamWriter(output_File))
                {
                    for (int i = 0; i < validCharacters.Length; i++)
                    {
                        string? line = inputFile.ReadLine();
                        if (line != null && line.Length > 100)
                        {
                            throw new Exception("Рядок з правилами команд перевищує 100 символів");
                        }

                        if (line != null)
                            foreach (char c in line)
                            {
                                characterCounts[i][directionIndices[c]] += 1;
                            }
                    }

                    string[] inputStrings = inputFile.ReadLine()!.Split(' ');
                    string directionResult = inputStrings[0];
                    int parameterResult = int.Parse(inputStrings[1]);

                    // ініціалізація списку 'count' для підрахунку результатів
                    for (int i = 0; i <= parameterResult; i++)
                    {
                        resultCount.Add(new int[validCharacters.Length]);
                        for (int j = 0; j < validCharacters.Length; j++)
                        {
                            resultCount[i][j] = 1;
                        }
                    }

                    for (int par = 2; par <= parameterResult; par++)
                    {
                        for (int parentDir = 0; parentDir < validCharacters.Length; parentDir++)
                        {
                            for (int childDir = 0; childDir < validCharacters.Length; childDir++)
                            {
                                int res = resultCount[par - 1][childDir] * characterCounts[parentDir][childDir];
                                resultCount[par][parentDir] += res;
                            }
                        }
                    }

                    outputFile.WriteLine(resultCount[parameterResult][directionIndices[directionResult[0]]]);
                }
            }
        }
    }
}