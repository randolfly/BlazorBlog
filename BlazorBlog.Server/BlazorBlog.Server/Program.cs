using BlazorBlog.Server.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRenderItemService, RenderItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

// E:\Code\C#\Tool\BlazorBlog\BlazorBlog.Server\assets\hello.md
app.MapGet("/parse-markdown-to-html", async (string markdownFilePath) =>
    {
        Console.WriteLine(markdownFilePath);
        var markdown = File.ReadAllText(markdownFilePath);

        var service = new RenderItemService();
        var html = service.ParseMarkdownToHtml(markdown);
        return html;
    }).WithName("ParseMarkdownToHtml")
    .WithOpenApi();

// E:\Code\C#\Tool\BlazorBlog\BlazorBlog.Server\assets\hello.md
app.MapGet("/parse-markdown-to-dom", async (string markdownFilePath) =>
    {
        Console.WriteLine(markdownFilePath);
        var markdown = File.ReadAllText(markdownFilePath);

        var service = new RenderItemService();
        var dom = await service.ParseMarkdown(markdown);
        return dom;
    }).WithName("ParseMarkdownToDom")
    .WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}