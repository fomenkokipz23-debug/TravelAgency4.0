using System;
using System.Collections.Generic;

namespace TravelAgency.Domain;

public class Tour
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public List<string> RoutePlaces { get; set; } 

    public Tour()
    {
        Id = Guid.NewGuid();
        Name = "Базовий Екскурсійний Тур";
        BasePrice = 3000m;
        RoutePlaces = new List<string>();
    }

    public Tour(string name, decimal basePrice, List<string> routePlaces)
    {
        Id = Guid.NewGuid();
        Name = name;
        BasePrice = basePrice;
        RoutePlaces = new List<string>(routePlaces);
    }

    public Tour(Tour other)
    {
        Id = other.Id;
        Name = other.Name;
        BasePrice = other.BasePrice;
        RoutePlaces = new List<string>(other.RoutePlaces);
    }
}