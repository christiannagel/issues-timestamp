// See https://aka.ms/new-console-template for more information
using System.Text.Json;

JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true,
};

Test t1 = new(Guid.NewGuid(), TimeSpan.FromSeconds(10));

string json = JsonSerializer.Serialize(t1);

try
{
    Test? t2 = JsonSerializer.Deserialize<Test>(json, options: jsonOptions);
    Console.WriteLine(t2?.Id);
    Console.WriteLine(t2?.Duration);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


public record class Test(Guid Id, TimeSpan Duration);