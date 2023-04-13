using CompanyManager.Helpers;
using CompanyManager.Shared.DataTransferObjects.Responses;
using CompanyManager.Shared.HttpClients;

namespace CompanyManager.Clients;

public class MockJsonApiClient
{
    private readonly MockHttpClient _mock;

    public MockJsonApiClient(MockHttpClient mock)
    {
        _mock = mock;
    }

    public async Task<List<UserDto>> GetUsers()
    {
        var response = await _mock.Client.GetAsync("/users");

        var result =
            await Deserializer<List<UserDto>>.Deserialize(response);

        return result;
    }
}