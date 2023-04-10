using CompanyManager.Clients;

var client = new MockJsonApiClient();

var x = await client.GetUsers();

foreach (var u in x)
{
    Console.WriteLine(u.Name);
}