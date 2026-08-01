using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Database Context ko yahan Register karein
builder.Services.AddDbContext<LibraryContext>();

// Controllers ke sath ReferenceHandler add kiya taake loop/cycle ka error na aaye
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Database Ensure Created & Data Seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LibraryContext>();
    
    context.Database.EnsureCreated();

    if (!context.Authors.Any())
    {
        var author = new Author { Name = "Robert C. Martin", Country = "USA" };
        context.Authors.Add(author);
        context.SaveChanges();

        context.Books.Add(new Book
        {
            Title = "Clean Code",
            Genre = "Programming",
            Price = 1200,
            AuthorID = author.AuthorID
        });

        context.SaveChanges();
    }
}

// 3. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Controllers map karna
app.MapControllers();

app.Run();