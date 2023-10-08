using System;
using System.IO;
using System.Numerics;

public class Solution
{
    public void Run()
    {
        StreamReader inputFile = new StreamReader("INPUT.TXT");
        StreamWriter outputFile = new StreamWriter("OUTPUT.TXT");

        string[] input = inputFile.ReadLine().Split(' ');
        int n = int.Parse(input[0]);  // максимальна довжина рядка 
        int k = int.Parse(input[1]);  // к-сть літер в цьому алфавіті 
        
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
        Solution solution = new Solution();
        solution.Run();
    }
}
