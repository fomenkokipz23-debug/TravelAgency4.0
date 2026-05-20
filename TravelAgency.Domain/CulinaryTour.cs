using System.Collections.Generic;

namespace TravelAgency.Domain;

public class CulinaryTour : Tour
{
    public int TastingsCount { get; set; }
    public decimal PricePerTasting { get; set; }

    public CulinaryTour(string name, decimal basePrice, Route route, int tastingsCount, decimal pricePerTasting)
        : base(name, basePrice, route)
    {
        TastingsCount = tastingsCount;
        PricePerTasting = pricePerTasting;
    }

    public override decimal GetPrice()
    {
        return BasePrice + (TastingsCount * PricePerTasting);
    }
}