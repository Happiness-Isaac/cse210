using System;

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private string _postalCode;

    public Address(string street, string city, string state, string country, string postalCode)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
        _postalCode = postalCode;
    }

    public string GetStreet()
    {
        return _street;
    }

    public void SetStreet(string street)
    {
        _street = street;
    }

    public string GetCity()
    {
        return _city;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    public string GetState()
    {
        return _state;
    }

    public void SetState(string state)
    {
        _state = state;
    }

    public string GetCountry()
    {
        return _country;
    }

    public void SetCountry(string country)
    {
        _country = country;
    }

    public string GetPostalCode()
    {
        return _postalCode;
    }

    public void SetPostalCode(string postalCode)
    {
        _postalCode = postalCode;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state} {_postalCode}\n{_country}";
    }

    public override string ToString()
    {
        return GetFullAddress();
    }
}