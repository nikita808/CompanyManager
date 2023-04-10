using System.Text.Json;
using CompanyManager.Entities.Exceptions;

namespace CompanyManager.Helpers;

public static class Deserializer<T> where T : class, new()
{
    public static async Task<T> Deserialize(HttpResponseMessage message)
    {
        return await DeserializeObject(message);
    }

    private static async Task<T> DeserializeObject(HttpResponseMessage message)
    {
        if (!message.IsSuccessStatusCode)
        {
            throw new ErrorInRequestException(await message.Content.ReadAsStringAsync());
        }

        var content = await message.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content)!;
    }
}