using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

List<Item> items = new List<Item>();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Basic routes
app.MapGet("/", () => "Welcome to the Simple Web API!");

// GET all items
app.MapGet("/items", () => items);

// GET a specific item by ID
app.MapGet("/items/{id:int}", (int id) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

// POST a new item
app.MapPost("/items", (Item newItem) =>
{
    newItem.Id = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1;
    items.Add(newItem);
    return Results.Created($"/items/{newItem.Id}", newItem);
});

// PUT to update an existing item
app.MapPut("/items/{id:int}", (int id, Item updatedItem) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    if (item is null)
    {
        return Results.NotFound();
    }

    item.Name = updatedItem.Name;
    item.Description = updatedItem.Description;
    item.Price = updatedItem.Price;

    return Results.Ok(item);
});

// DELETE an item by ID
app.MapDelete("/items/{id:int}", (int id) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    if (item is null)
    {
        return Results.NotFound();
    }

    items.Remove(item);
    return Results.NoContent();
});

app.Run();

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}