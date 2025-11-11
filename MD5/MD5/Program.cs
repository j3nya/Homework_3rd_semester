// <copyright file="Program.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Diagnostics;
using MD5;

if (args.Length == 1)
{
    string filePath = args[0];
    if (!Directory.Exists(filePath) && !File.Exists(filePath))
    {
        throw new FileNotFoundException(filePath);
    }

    var stopwatch = new Stopwatch();
    stopwatch.Start();
    CheckSumSequentially.GetCheckSum(args[0]);
    stopwatch.Stop();
    Console.WriteLine($"Sequential realisation time(ms): {stopwatch.ElapsedMilliseconds}");

    stopwatch.Reset();
    stopwatch.Start();
    CheckSumConcurrently.GetCheckSum(args[0]);
    Console.WriteLine($"Concurrent realisation time(ms): {stopwatch.ElapsedMilliseconds}");
}