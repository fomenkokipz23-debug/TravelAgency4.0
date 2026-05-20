using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Domain;

public static class TourExtensions
{
    public static IEnumerable<Tour> FilterByCity(this IEnumerable<Tour> tours, string cityName)
    {
        if (string.IsNullOrWhiteSpace(cityName)) return tours;

        return tours
            .Where(t => t.TourRoute.Cities.Contains(cityName, StringComparer.OrdinalIgnoreCase))
            .OrderBy(t => t.GetPrice());
    }
}