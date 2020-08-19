using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Data.Interfaces
{
    interface INumbersAPIService
    {
        Task<string> GetTrivia(int number, CancellationToken cancellationToken = default);
        Task<string> GetMath(int number, CancellationToken cancellationToken = default);
        Task<string> GetRandomMath(CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetManyRandomMath(int count, CancellationToken cancellationToken = default);
        Task<string> GetRandomTrivia(CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetManyRandomTrivia(int count, CancellationToken cancellationToken = default);
    }
}
