using CompanyManager.Clients;
using CompanyManager.Shared.HttpClients;

var client = new MockJsonApiClient(new MockHttpClient(new HttpClient()));

var x = await client.GetUsers();

foreach (var u in x)
{
    Console.WriteLine(u.Name);
}