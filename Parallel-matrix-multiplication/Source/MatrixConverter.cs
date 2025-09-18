// <copyright file="MatrixConverter.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace Parallel_Matrix_Multiplication;

/// <summary>
/// Converts matrix to string array representation and vice versa.
/// </summary>
public class MatrixConverter()
{
    /// <summary>
    /// Checks if string array matrix representation is in correct format.
    /// </summary>
    /// <param name="matrixStringArrayRepresentation">String array to check.</param>
    /// <returns>A value indicating whether representation is valid.</returns>
    public static bool CheckIfStringsAreInACorrectFormat(string[] matrixStringArrayRepresentation)
    {
        int columns = matrixStringArrayRepresentation[0].Split(" ").Length;
        for (int i = 0; i < matrixStringArrayRepresentation.Length; i++)
        {
            var currentRow = matrixStringArrayRepresentation[i].Split(" ");
            if (currentRow.Length != columns)
            {
                throw new ArgumentOutOfRangeException("Incorrect amount of elements in a row");
            }

            for (int j = 0; j < columns; j++)
            {
                if (!int.TryParse(currentRow[j], out int _))
                {
                    throw new ArgumentException("All of the elements should be an integer");
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Converts string array to matrix.
    /// </summary>
    /// <param name="matrixStringArrayRepresentation">Matrix string array representation to convert.</param>
    /// <returns>Integer 2d matrix from string array.</returns>
    public static int[,] StringArrayToMatrix(string[] matrixStringArrayRepresentation)
    {
        CheckIfStringsAreInACorrectFormat(matrixStringArrayRepresentation);
        var columns = matrixStringArrayRepresentation[0].Split(" ").Length;
        var rows = matrixStringArrayRepresentation.Length;
        var result = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            var elements = matrixStringArrayRepresentation[i].Split(" ");
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = int.Parse(elements[j]);
            }
        }

        return result;
    }

    /// <summary>
    /// Converts integer 2d matrix to string array.
    /// </summary>
    /// <param name="matrix">Matrix to convert.</param>
    /// <returns>String array matrix representation.</returns>
    public static string[] MatrixToStringArray(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var columns = matrix.GetLength(1);
        var result = new string[rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns - 1; j++)
            {
                result[i] += $"{matrix[i, j]} ";
            }

            result[i] += $"{matrix[i, columns - 1]}";
        }

        return result;
    }
}