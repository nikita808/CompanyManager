namespace CompanyManager.Shared.HttpClients;

public class MockHttpClient
{
    public HttpClient Client { get; }

    public MockHttpClient(HttpClient client)
    {
        Client = client;
        Client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
        Client.Timeout = new TimeSpan(0, 0, 30);
        Client.DefaultRequestHeaders.Clear();
    }
}