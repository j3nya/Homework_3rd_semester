// <copyright file="ConcurrentMultiplicator.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Parallel_Matrix_Multiplication;

/// <summary>
/// Multiplication operator.
/// </summary>
public class ConcurrentMultiplicator()
{
    /// <summary>
    /// Multiplies two matrices.
    /// </summary>
    /// <param name="firstOperand">First operand.</param>
    /// <param name="secondOperand">Second operand.</param>
    /// <returns>Product.</returns>
    public static int[,] Multiplicate(int[,] firstOperand, int[,] secondOperand)
    {
        if (firstOperand.GetLength(1) != secondOperand.GetLength(0))
        {
            throw new Exception();
        }

        var rows2 = firstOperand.GetLength(1);
        var rows1 = firstOperand.GetLength(0);
        var columns2 = secondOperand.GetLength(1);
        var result = new int[rows1, columns2];
        var threads = new Thread[Environment.ProcessorCount];
        var chunkSize = (rows1 / threads.Length) + 1;

        for (int t = 0; t < threads.Length; t++)
        {
            int localT = t;
            threads[t] = new Thread(() =>
            {
                for (int i = localT * chunkSize; i < (localT + 1) * chunkSize && i < rows1; i++)
                {
                    for (int j = 0; j < columns2; j++)
                    {
                        for (int k = 0; k < rows2; k++)
                        {
                            result[i, j] += firstOperand[i, k] * secondOperand[k, j];
                        }
                    }
                }
            });
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return result;
    }
}