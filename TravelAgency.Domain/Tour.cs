using System;

namespace TravelAgency.Domain;

public class Tour
{
    private decimal _basePrice;
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Route TourRoute { get; set; }

    public decimal BasePrice
    {
        get => _basePrice;
        set
        {
            if (value < 0)
                throw new ArgumentException("Базова вартість туру не може бути меншою за 0.");
            _basePrice = value;
        }
    }

    public Tour()
    {
        Id = Guid.NewGuid();
        Name = "Базовий Екскурсійний Тур";
        BasePrice = 3000m;
        TourRoute = new Route();
    }

    public Tour(string name, decimal basePrice, Route route)
    {
        Id = Guid.NewGuid();
        Name = name;
        BasePrice = basePrice;
        TourRoute = route;
    }

    public Tour(Tour other)
    {
        Id = other.Id;
        Name = other.Name;
        BasePrice = other.BasePrice;
        TourRoute = new Route();
        foreach (var city in other.TourRoute.Cities)
        {
            TourRoute = TourRoute + city;
        }
    }
}