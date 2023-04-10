using CompanyManager.Entities.Responses;
using CompanyManager.Helpers;

namespace CompanyManager.Clients;

public class MockJsonApiClient
{
    private readonly HttpClient _httpClient;

    public MockJsonApiClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
        };
    }

    public async Task<List<User>> GetUsers()
    {
        var response = await _httpClient.GetAsync("/users");

        var result =
            await Deserializer<List<User>>.Deserialize(response);

        return result;
    }
}