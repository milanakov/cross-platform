using System;
using System.Collections.Generic;
using System.IO;

namespace lab4_cross_library
{
    public class Lab3
    {
        public static void RunLab3(string input_File, string output_File)
        {
            using (StreamReader inputFile = new StreamReader(input_File))
            using (StreamWriter outputFile = new StreamWriter(output_File))
            {
                string[]? line = inputFile.ReadLine()?.Split();

                if (line == null || line.Length != 2)
                {
                    Console.WriteLine("Некоректний формат вхідних даних.");
                    return;
                }

                int n = int.Parse(line[0]); // Кількість вершин
                int m = int.Parse(line[1]); // Кількість ребер
                
                // списки для зберігання інформації про ребра та відстані
                List<int> startVertex = new List<int>();
                List<int> endVertex = new List<int>();
                List<int> edgeWeight = new List<int>();
                List<int> distances = new List<int>();

                const int INF = 1000000000;

                // Зчитування інформації про ребра графа
                for (int i = 0; i < m; i++)
                {
                    line = inputFile.ReadLine()?.Split();
                    if (line == null || line.Length != 3)
                    {
                        Console.WriteLine("Некоректний формат вхідних даних.");
                        return;
                    }
                    startVertex.Add(int.Parse(line[0])); // Початкова вершина ребра
                    endVertex.Add(int.Parse(line[1]));   // Кінцева вершина ребра
                    edgeWeight.Add(int.Parse(line[2]));  // Вага ребра
                }

                for (int i = 0; i < n; i++)
                {
                    distances.Add(INF);
                }

                distances[0] = 0;

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

                // Якщо шлях до вершини не існує, встановлюємо значення 30000
                for (int i = 0; i < n; i++)
                {
                    if (distances[i] == INF)
                    {
                        distances[i] = 30000;
                    }
                }

                outputFile.WriteLine(string.Join(" ", distances));
            }
        }
    }
}