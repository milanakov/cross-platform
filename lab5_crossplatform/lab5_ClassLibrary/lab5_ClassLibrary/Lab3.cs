using System;
using System.Collections.Generic;

namespace lab5_ClassLibrary
{
    public class Lab3
    {
        public string RunAlgorithmWithStringInput(string input)
        {
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0)
            {
                return "Некоректний формат вхідних даних.";
            }

            string[] firstLine = lines[0].Split();
            if (firstLine.Length != 2)
            {
                return "Некоректний формат вхідних даних.";
            }

            int n = int.Parse(firstLine[0]); // Кількість вершин
            int m = int.Parse(firstLine[1]); // Кількість ребер

            List<int> startVertex = new List<int>();
            List<int> endVertex = new List<int>();
            List<int> edgeWeight = new List<int>();
            List<int> distances = new List<int>(new int[n]);

            const int INF = 1000000000;
            for (int i = 0; i < n; i++)
            {
                distances[i] = INF;
            }
            distances[0] = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split();
                if (line.Length != 3)
                {
                    return "Некоректний формат вхідних даних.";
                }
                startVertex.Add(int.Parse(line[0]));
                endVertex.Add(int.Parse(line[1]));
                edgeWeight.Add(int.Parse(line[2]));
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (distances[endVertex[j] - 1] > distances[startVertex[j] - 1] + edgeWeight[j] && distances[startVertex[j] - 1] != INF)
                    {
                        distances[endVertex[j] - 1] = distances[startVertex[j] - 1] + edgeWeight[j];
                    }
                }
            }

            // Set unreachable distances to 30000
            for (int i = 0; i < n; i++)
            {
                if (distances[i] == INF)
                {
                    distances[i] = 30000;
                }
            }

            return string.Join(" ", distances);
        }
    }
}
