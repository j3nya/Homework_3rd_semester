// <copyright file="SequentialLazy.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.VisualBasic;

namespace Lazy;

/// <summary>
/// Implements ILazy for sequential case.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="function"></param>
public class SequentialLazy<T>(Func<T> function) : ILazy<T>
{
    private Func<T> 
    private T? value = default;

    public T Get()
    {
        if (!this.isInitialized)
        {
            this.isInitialized = true;
            this.value = supplier();
        }

        return this.value!;
    }
}