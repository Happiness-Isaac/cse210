using System;
using System.Collections.Generic;

class Order
{
    private static int _nextId = 1;

    private int _id;
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _id = _nextId++;
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double subtotal = 0;
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.0 : 35.0;
        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = $"Packing Label\nOrder {_id}\n";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} ({product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

    public int GetId()
    {
        return _id;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public double GetTotalAmount()
    {
        return GetTotalCost();
    }

    public string GetCountry()
    {
        return _customer.GetAddress().GetCountry();
    }
}