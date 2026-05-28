using System;

namespace TravelAgency.Domain;

public class Tour
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public Route TourRoute { get; set; }
    
    public string Description { get; set; } = "Прекрасна подорож з незабутніми краєвидами.";
    public string HotelImage3Star { get; set; } = "https://images.unsplash.com/photo-1566073771259-6a8506099945?q=80&w=600&auto=format&fit=crop";
    public string HotelImage5Star { get; set; } = "https://images.unsplash.com/photo-1582719508461-905c673771fd?q=80&w=600&auto=format&fit=crop";

    public Tour() { }

    public Tour(string name, decimal basePrice, Route tourRoute)
    {
        Name = name;
        BasePrice = basePrice;
        TourRoute = tourRoute;
    }

    public decimal GetPrice()
    {
        return BasePrice;
    }
}