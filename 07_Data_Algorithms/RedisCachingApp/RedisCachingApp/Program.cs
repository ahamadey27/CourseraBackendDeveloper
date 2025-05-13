using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Text.Json;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

// Configure Redis connection
services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost")); // Replace "localhost" with your Redis connection string if different

// Register your services that depend on IDatabase (or IConnectionMultiplexer)
// services.AddTransient<MyService>(); // Example service

var serviceProvider = services.BuildServiceProvider();

// Example of retrieving and using the Redis database
var redis = serviceProvider.GetService<IConnectionMultiplexer>();
if (redis != null)
{
    IDatabase db = redis.GetDatabase();
    Console.WriteLine("Successfully connected to Redis and got DB instance.");

    // Store Data in Cache
    string cacheKey = "product:123";
    string cacheValue = "Product Name: Awesome Gadget, Price: $99.99";
    db.StringSet(cacheKey, cacheValue);
    Console.WriteLine($"Stored in cache: Key='{cacheKey}', Value='{cacheValue}'");

    // Retrieve Data from Cache
    string? retrievedValue = db.StringGet(cacheKey);
    if (retrievedValue != null)
    {
        Console.WriteLine($"Retrieved from cache: Key='{cacheKey}', Value='{retrievedValue}'");
    }
    else
    {
        Console.WriteLine($"Cache miss for Key='{cacheKey}'");
    }

    // Invalidate Cache
    bool invalidated = db.KeyDelete(cacheKey);
    if (invalidated)
    {
        Console.WriteLine($"Invalidated cache for Key='{cacheKey}'");
    }
    else
    {
        Console.WriteLine($"Could not invalidate cache for Key='{cacheKey}' (key might not exist).");
    }

    // Verify Invalidation by trying to retrieve again
    retrievedValue = db.StringGet(cacheKey);
    if (retrievedValue == null)
    {
        Console.WriteLine($"Verified: Key='{cacheKey}' is no longer in cache after invalidation.");
    }
    else
    {
        Console.WriteLine($"Verification Failed: Key='{cacheKey}' still exists in cache with Value='{retrievedValue}'.");
    }

    // --- Simulate Caching a Product List ---
    Console.WriteLine("\n--- Simulating Product List Caching ---");
    string productListKey = "products:all";

    // Attempt to retrieve product list from cache
    string? cachedProductListJson = db.StringGet(productListKey);
    List<string>? productList;

    if (cachedProductListJson != null)
    {
        Console.WriteLine($"Cache HIT for '{productListKey}'. Deserializing product list.");
        productList = JsonSerializer.Deserialize<List<string>>(cachedProductListJson);
    }
    else
    {
        Console.WriteLine($"Cache MISS for '{productListKey}'. Simulating fetching from data source.");
        // Simulate fetching from a database or service
        productList = new List<string> { "Laptop", "Mouse", "Keyboard", "Monitor" };
        Console.WriteLine("Fetched product list from simulated data source.");

        // Serialize and store in cache for next time
        string productListToCacheJson = JsonSerializer.Serialize(productList);
        db.StringSet(productListKey, productListToCacheJson, TimeSpan.FromMinutes(5)); // Set an expiry, e.g., 5 minutes
        Console.WriteLine($"Stored product list in cache with key '{productListKey}'.");
    }

    if (productList != null && productList.Any())
    {
        Console.WriteLine("Current Product List:");
        foreach (var product in productList)
        {
            Console.WriteLine($"- {product}");
        }
    }
    else
    {
        Console.WriteLine("Product list is empty or could not be retrieved.");
    }

    // To demonstrate cache invalidation for the list (optional here, as it's part of the previous example)
    // db.KeyDelete(productListKey);
    // Console.WriteLine($"Invalidated product list cache for key '{productListKey}'.");
}
else
{
    Console.WriteLine("Failed to connect to Redis.");
}
