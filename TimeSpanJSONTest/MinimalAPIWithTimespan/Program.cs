using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, TestSourceGeneratorContext.Default);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    return new Test(Guid.NewGuid(), TimeSpan.FromSeconds(10));
});

app.MapPost("/test", (Test test) =>
{
    Console.WriteLine(test.Id);
    Console.WriteLine(test.Duration);
    return Results.Ok();
});

app.Run();

[JsonSerializable(typeof(Test))]
public partial class TestSourceGeneratorContext : JsonSerializerContext
{

}

public record class Test(Guid Id, TimeSpan Duration);
