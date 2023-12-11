using System;
using System.Numerics;

namespace lab5_ClassLibrary
{
    public class Lab1
    {
        public string RunAlgorithmWithStringInput(string input)
        {
            string[] inputParts = input.Split(' ');

            if (inputParts.Length < 2 || !int.TryParse(inputParts[0], out int n) || !int.TryParse(inputParts[1], out int k))
            {
                return "Некоректний вхідний формат.";
            }

            if (n < 1 || n > 1000)
            {
                return "Значення n має бути в межах від 1 до 1000.";
            }

            if (k < 1 || k > 100)
            {
                return "Значення k має бути в межах від 1 до 100.";
            }

            BigInteger alphabetSizeBigInt = new BigInteger(k);
            BigInteger temp = BigInteger.One;
            BigInteger totalStrings = BigInteger.Zero; // к-сть рядків
            BigInteger numShortStrings = BigInteger.One; // к-сть коротких рядків (<= n/2)

            int halfMaxLength = n / 2;

            for (int i = 0; i < halfMaxLength; i++)
            {
                temp *= alphabetSizeBigInt; // k^n/2
            }

            if ((n & 1) == 0)
            {
                numShortStrings += temp;
            }

            for (int i = halfMaxLength; i < n; i++)
            {
                temp *= alphabetSizeBigInt;
                totalStrings += temp;
            }

            return $"{totalStrings}<br>{numShortStrings}";
        }
    }
}