using MinimalBookApi.Database;
using static MinimalBookApi.Database.BookManager;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<DatabaseManager>();
builder.Services.AddTransient<BookManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var databaseManager = app.Services.GetRequiredService<DatabaseManager>();

app.MapPost("/books", async (BookManager bookManager, Book book) =>
{
    if (book is null)
    {
        return Results.BadRequest();
    }

    var cbook = await bookManager.CreateBook(book);

    //return Results.Ok(cbook);

    if (cbook is null)
        return Results.BadRequest("Failed to create book.");
    else
        return Results.Ok(cbook);
});

app.MapGet("/books", async (BookManager bookManager) => {
    var books = await bookManager.GetBooks();

    return Results.Ok(books);
});

app.Run();