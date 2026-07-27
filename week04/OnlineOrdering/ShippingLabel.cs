class ShippingLabel
{
    private string _customerName;
    private string _shippingAddress;
    private string _country;

    public ShippingLabel(string customerName, string shippingAddress, string country)
    {
        _customerName = customerName;
        _shippingAddress = shippingAddress;
        _country = country;
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public string GetShippingAddress()
    {
        return _shippingAddress;
    }

    public string GetCountry()
    {
        return _country;
    }

    public override string ToString()
    {
        return $"Shipping Label for {_customerName}\n{_shippingAddress}\n{_country}";
    }
}