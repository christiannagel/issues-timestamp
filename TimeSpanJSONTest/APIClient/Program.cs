using System.Net.Http.Json;

Console.WriteLine("client...");
string? c = Console.ReadLine();
HttpClient client = new HttpClient();
var t1 = await client.GetFromJsonAsync<Test>("https://localhost:7089/test");
Console.WriteLine(t1?.Id);
Console.WriteLine(t1?.Duration);

Test t2 = new(Guid.NewGuid(), TimeSpan.FromSeconds(30));
await client.PostAsJsonAsync("https://localhost:7089/test", t2);

public record class Test(Guid Id, TimeSpan Duration);
