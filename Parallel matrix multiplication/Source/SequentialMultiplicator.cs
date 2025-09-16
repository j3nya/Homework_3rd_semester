// <copyright file="SequentialMultiplicator.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

/// <summary>
/// Multiplication operator.
/// </summary>
public class SequentialMultiplicator()
{
    public static int[,] MultiplicateSequentially(int[,] firstOperand, int[,] secondOperand)
    {
        if (firstOperand.GetLength(1) != secondOperand.GetLength(0))
        {
            throw new Exception();
        }

        int rows2 = firstOperand.GetLength(1);
        int rows1 = firstOperand.GetLength(0);
        int columns2 = secondOperand.GetLength(1);
        int[,] result = new int[rows1, columns2];
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < columns2; j++)
            {
                for (int k = 0; k < rows2; k++)
                {
                    result[i, j] += firstOperand[i, k] * secondOperand[k, j];
                }
            }
        }

        return result;
    }
}