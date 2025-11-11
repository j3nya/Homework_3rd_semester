// <copyright file="CheckSumSequentially.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace MD5;

using System.Linq;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// A class for sequential checksum calculation.
/// </summary>
public class CheckSumSequentially()
{
    /// <summary>
    /// A method for calculating the checksum.
    /// </summary>
    /// <param name="filePath">File Path.</param>
    /// <returns>Checksum of the given path.</returns>
    public static byte[] GetCheckSum(string filePath)
    {
        var filePathName = Path.GetDirectoryName(filePath);
        var summ = Encoding.ASCII.GetBytes(filePathName!);
        var files = Directory.GetFiles(filePath);
        string[] directories = Directory.GetDirectories(filePath);

        Array.Sort(directories);
        Array.Sort(files);

        foreach (string file in files)
        {
            byte[] hash = MD5.HashData(File.ReadAllBytes(file));
            summ = summ.Concat(hash).ToArray();
        }

        foreach (string directory in directories)
        {
            summ = [.. summ, .. GetCheckSum(directory)];
        }

        return MD5.HashData(summ);
    }
}