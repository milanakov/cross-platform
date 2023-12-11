using System;
using System.Collections.Generic;
using System.Linq;

namespace lab5_ClassLibrary
{
    public class Lab2
    {
        public string RunAlgorithmWithStringInput(string input)
        {
            int[] directionIndices = new int[1 + 'Z'];
            for (int i = 0; i < directionIndices.Length; i++)
            {
                directionIndices[i] = -1;
            }

            List<int[]> characterCounts = new List<int[]>();
            List<int[]> resultCount = new List<int[]>();
            char[] validCharacters = new char[] { 'N', 'S', 'W', 'E', 'U', 'D' };

            // Mapping characters to their indices in the directions array
            for (int i = 0; i < validCharacters.Length; i++)
            {
                directionIndices[validCharacters[i]] = i;
            }
            
            for (int i = 0; i < validCharacters.Length; i++)
            {
                characterCounts.Add(new int[validCharacters.Length]);
            }

            // Splitting input into lines
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (lines.Length < validCharacters.Length + 1)
            {
                throw new Exception("Input does not contain enough lines.");
            }

            for (int i = 0; i < validCharacters.Length; i++)
            {
                string line = lines[i];
                if (line.Length > 100)
                {
                    throw new Exception("Рядок з правилами команд перевищує 100 символів");
                }

                foreach (char c in line)
                {
                    if (directionIndices[c] != -1)
                    {
                        characterCounts[i][directionIndices[c]] += 1;
                    }
                }
            }

            string[] inputStrings = lines[validCharacters.Length].Split(' ');
            string directionResult = inputStrings[0];
            int parameterResult = int.Parse(inputStrings[1]);

            // Initialize 'count' list for counting results
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

            return resultCount[parameterResult][directionIndices[directionResult[0]]].ToString();
        }
    }
}
