﻿using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    // todo: change this method to support cancellation token
    public async static Task<long> Calculate(int n, CancellationToken token)
    {
        long sum = 0;

        for (var i = 0; i < n; i++)
        {
            // i + 1 is to allow 2147483647 (Max(Int32)) 
            sum += (i + 1);
            await Task.Delay(10, token);
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
        }
        return sum;
    }
}
