using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA", "84601");
        Customer customer1 = new Customer("Ava", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P100", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P101", 25.0, 2));

        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada", "M5V 2T6");
        Customer customer2 = new Customer("Ben", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "P102", 79.99, 1));
        order2.AddProduct(new Product("Headphones", "P104", 49.99, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine($"Order ID: {order.GetId()}");
            Console.WriteLine($"Customer: {order.GetCustomer().GetName()}");
            Console.WriteLine($"Total Amount: {order.GetTotalAmount():C}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
        }
    }
}