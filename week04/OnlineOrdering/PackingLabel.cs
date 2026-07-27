class PackingLabel
{
    private string _customerName;
    private string _shippingAddress;

    public PackingLabel(string customerName, string shippingAddress)
    {
        _customerName = customerName;
        _shippingAddress = shippingAddress;
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public string GetShippingAddress()
    {
        return _shippingAddress;
    }

    public override string ToString()
    {
        return $"Packing Label for {_customerName}\n{_shippingAddress}";
    }
}