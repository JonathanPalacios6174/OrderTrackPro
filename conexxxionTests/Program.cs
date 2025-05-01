using conexxxionTests.Models;

using (var db = new NorthwindContext()) 
{
    var orders = db.Orders.ToList();
    foreach (var order in orders)
    {
        Console.WriteLine($"Order ID: {order.OrderId}, Customer ID: {order.CustomerId}, Order Date: {order.OrderDate}");
    }
}

    // See https://aka.ms/new-console-template for more information
    Console.WriteLine("Hello, World!");

