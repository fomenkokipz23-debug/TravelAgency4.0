using System.Collections.Generic;

namespace TravelAgency.Domain;

public class ComplexTourBuilder
{
    private CustomTour _customTour = new();

    public ComplexTourBuilder StartNewBuild()
    {
        _customTour = new CustomTour();
        return this;
    }

    public ComplexTourBuilder BuildFlight(string classType, decimal cost)
    {
        _customTour.FlightDetails = $"{classType} клас";
        _customTour.AdditionalCost += cost;
        return this;
    }

    public ComplexTourBuilder BuildHotel(string hotelName, decimal cost)
    {
        _customTour.HotelDetails = hotelName;
        _customTour.AdditionalCost += cost;
        return this;
    }

    public ComplexTourBuilder AddExcursion(string name, decimal cost)
    {
        _customTour.SelectedExcursions.Add(name);
        _customTour.AdditionalCost += cost;
        return this;
    }

    public CustomTour Build()
    {
        return _customTour;
    }
}