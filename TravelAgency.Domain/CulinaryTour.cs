using System.Collections.Generic;

namespace TravelAgency.Domain;

public class CulinaryTour : Tour
{
    public int TastingsCount { get; set; }
    public decimal PricePerTasting { get; set; }

    public CulinaryTour(string name, decimal basePrice, Route tourRoute, int tastingsCount, decimal pricePerTasting) 
        : base(name, basePrice, tourRoute)
    {
        TastingsCount = tastingsCount;
        PricePerTasting = pricePerTasting;
    }
    
}