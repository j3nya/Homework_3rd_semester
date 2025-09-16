// <copyright file="Program.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
int[,] qu =
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 },
};
int[,] seqmul = SequentialMultiplicator.MultiplicateSequentially(qu, qu);
for (int i = 0; i < seqmul.GetLength(0); i++)
{
    for (int j = 0; j < seqmul.GetLength(1); j++)
    {
        Console.Write($"{seqmul[i, j]} ");
    }

    Console.Write("\n");
}

int[,] conmul = ConcurrentMultiplicator.MultiplicateConcurrently(qu, qu);
for (int i = 0; i < conmul.GetLength(0); i++)
{
    for (int j = 0; j < conmul.GetLength(1); j++)
    {
        Console.Write($"{conmul[i, j]} ");
    }

    Console.Write("\n");
}