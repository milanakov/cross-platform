using System;
using System.IO;
using System.Numerics;

public class Solution 
{
    public void Run(StreamReader inputFile, StreamWriter outputFile)
    {
        string[] input = inputFile.ReadLine()!.Split(' ');

        if (input.Length < 2 || !int.TryParse(input[0], out int n) || !int.TryParse(input[1], out int k))
        {
            outputFile.WriteLine("Некоректний вхідний формат.");
            inputFile.Close();
            outputFile.Close();
            return;
        }
        
        if (n < 1 || n > 1000)
        {
            outputFile.WriteLine("Значення n має бути в межах від 1 до 1000");
            inputFile.Close();
            outputFile.Close();
            return;
        }

        if (k < 1 || k > 100)
        {
            outputFile.WriteLine("Значення k має бути в межах від 1 до 100");
            inputFile.Close();
            outputFile.Close();
            return;
        }

        BigInteger alphabetSizeBigInt = new BigInteger(k);
        BigInteger temp = BigInteger.One;
        BigInteger totalStrings = BigInteger.Zero;     // к-сть рядків
        BigInteger numShortStrings = BigInteger.One;   // к-сть коротких рядків (<= n/2)

        int halfMaxLength = n / 2;

        for (int i = 0; i < halfMaxLength; i++)
        {
            temp = temp * alphabetSizeBigInt;  // k^n/2
        }
        
        if ((n & 1) == 0)
        {
            numShortStrings = numShortStrings + temp;
        }
        
        for (int i = halfMaxLength; i < n; i++)
        {
            temp = temp * alphabetSizeBigInt;
            totalStrings = totalStrings + temp;
        }
        
        outputFile.WriteLine(totalStrings);
        outputFile.WriteLine(numShortStrings);
        
        inputFile.Close();
        outputFile.Close();
    }

    public static void Main(string[] args)
    {
        using (StreamReader inputFile = new StreamReader("INPUT.TXT"))
        using (StreamWriter outputFile = new StreamWriter("OUTPUT.TXT"))
        {
            Solution solution = new Solution();
            solution.Run(inputFile, outputFile);
        }
    }
}
