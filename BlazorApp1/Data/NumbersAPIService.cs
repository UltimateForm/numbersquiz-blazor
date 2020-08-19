using BlazorApp1.Data.Interfaces;
using BlazorApp1.Data.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class NumbersAPIService : INumbersAPIService
    {
        protected HttpClient _httpClient;
        protected NumbersAPIOptions _options;

        public NumbersAPIService(HttpClient httpClient,IOptions<NumbersAPIOptions> options)
        {
            _options = options.Value;
            Console.Write(options.Value.Address);
            _httpClient = httpClient;
            Console.WriteLine(httpClient.GetType());
        }
        
        protected void FillRequestHeadersWithCommonHeaders(HttpRequestHeaders headers)
        {
            foreach (var item in _options.CommonHeaders)
            {
                headers.Add(item.Key, item.Value);
            }
        }
        
        public async Task<IEnumerable<string>> GetManyRandomMath(int count, CancellationToken cancellationToken = default)
        {
            var requests = Enumerable.Range(0, count).Select((i) =>
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_options.Address}/random/math?max=9999"),
                };
                FillRequestHeadersWithCommonHeaders(requestMessage.Headers);
                return _httpClient.SendAsync(requestMessage, cancellationToken);
            });
            var responses = await Task.WhenAll(requests);
            if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();
            var texts = await Task.WhenAll(responses.Select(r => r.Content.ReadAsStringAsync()));
            if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();
            return texts.AsEnumerable();
        }

        public async Task<IEnumerable<string>> GetManyRandomTrivia(int count, CancellationToken cancellationToken = default)
        {
            var requests = Enumerable.Range(0, count).Select((i) =>
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_options.Address}/random/trivia?max=9999"),
                };
                FillRequestHeadersWithCommonHeaders(requestMessage.Headers);
                return _httpClient.SendAsync(requestMessage, cancellationToken);
            });
            var responses = await Task.WhenAll(requests);
            if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();
            var texts = await Task.WhenAll(responses.Select(r => r.Content.ReadAsStringAsync()));
            if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();
            return texts.AsEnumerable();
        }

        public async Task<string> GetMath(int number, CancellationToken cancellationToken= default)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_options.Address}/{number}/math"),
            };
            FillRequestHeadersWithCommonHeaders(requestMessage.Headers);
            var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            var text = await response.Content.ReadAsStringAsync();
            return text;
        }

        public async Task<string> GetRandomMath(CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_options.Address}/random/math?max=9999"),
            };
            FillRequestHeadersWithCommonHeaders(requestMessage.Headers);
            var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            var text = await response.Content.ReadAsStringAsync();
            return text;
        }

        public async Task<string> GetRandomTrivia(CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_options.Address}/random/math?max=9999"),
            };
            FillRequestHeadersWithCommonHeaders(requestMessage.Headers);
            var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            var text = await response.Content.ReadAsStringAsync();
            return text;
        }

        public async Task<string> GetTrivia(int number, CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_options.Address}/{number}/trivia"),
            };
            FillRequestHeadersWithCommonHeaders(requestMessage.Headers);
            var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            var text = await response.Content.ReadAsStringAsync();
            return text;
        }
    }
}
