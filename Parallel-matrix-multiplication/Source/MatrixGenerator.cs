// <copyright file="MatrixGenerator.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace Parallel_Matrix_Multiplication;

/// <summary>
/// Generates random matrix with given size.
/// </summary>
public class MatrixGenerator()
{
    /// <summary>
    /// Generate matrix with random numbers as elements with given size.
    /// </summary>
    /// <param name="n">Rows count.</param>
    /// <param name="m">Columns count.</param>
    /// <returns>Generated matrix.</returns>
    public static int[,] GenerateMatrix(int n, int m)
    {
        var result = new int[n, m];
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result[i, j] = random.Next(short.MaxValue);
            }
        }

        return result;
    }
}