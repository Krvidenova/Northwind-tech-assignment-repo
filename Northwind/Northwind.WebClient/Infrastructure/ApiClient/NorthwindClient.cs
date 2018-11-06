namespace Northwind.WebClient.Infrastructure.ApiClient
{
    using System;
    using System.Net.Http;

    public class NorthwindClient
    {
        public NorthwindClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44330/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.Client = httpClient;
        }

        public HttpClient Client { get; private set; }
    }
}