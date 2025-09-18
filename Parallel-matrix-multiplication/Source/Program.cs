// <copyright file="Program.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using Parallel_Matrix_Multiplication;

if (args.Length == 2)
{
    var firstOperand = MatrixConverter.StringArrayToMatrix(File.ReadAllLines(args[0]));
    var secondOperand = MatrixConverter.StringArrayToMatrix(File.ReadAllLines(args[1]));

    // var result = ConcurrentMultiplicator.Multiplicate(firstOperand, secondOperand);
    var result = SequentialMultiplicator.Multiplicate(firstOperand, secondOperand);
    File.WriteAllLines("result.txt", MatrixConverter.MatrixToStringArray(result));
}