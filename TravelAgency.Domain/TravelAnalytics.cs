using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Domain;

public class TravelAnalytics
{
    public Dictionary<string, decimal> GetMaxPriceByStartCity(IEnumerable<Tour> tours)
    {
        return tours
            .Where(t => t.TourRoute.PlacesCount > 0)
            .GroupBy(t => t.TourRoute[0]) 
            .ToDictionary(
                group => group.Key,
                group => group.Max(t => t.GetPrice()) 
            );
    }

    public string GenerateToursSummary(IEnumerable<Tour> tours)
    {
        if (!tours.Any()) return "Немає доступних турів";

        return tours
            .Select(t => t.Name)
            .Aggregate((current, next) => current + ", " + next);
    }
}