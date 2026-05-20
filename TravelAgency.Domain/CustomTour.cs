using System.Collections.Generic;

namespace TravelAgency.Domain;

public class TourMemento
{
    public string Flight { get; }
    public string Hotel { get; }
    public List<string> Excursions { get; }
    public decimal AdditionalCost { get; }

    public TourMemento(string flight, string hotel, List<string> excursions, decimal additionalCost)
    {
        Flight = flight;
        Hotel = hotel;
        Excursions = new List<string>(excursions);
        AdditionalCost = additionalCost;
    }
}

public class CustomTour
{
    public string FlightDetails { get; set; } = "Не обрано";
    public string HotelDetails { get; set; } = "Не обрано";
    public List<string> SelectedExcursions { get; set; } = new();
    public decimal AdditionalCost { get; set; }

    public TourMemento Save()
    {
        return new TourMemento(FlightDetails, HotelDetails, SelectedExcursions, AdditionalCost);
    }

    public void Restore(TourMemento memento)
    {
        if (memento == null) return;
        FlightDetails = memento.Flight;
        HotelDetails = memento.Hotel;
        SelectedExcursions = new List<string>(memento.Excursions);
        AdditionalCost = memento.AdditionalCost;
    }

    public string GetSummary()
    {
        return $"✈️ Авіапереліт: {FlightDetails} | 🏨 Проживання: {HotelDetails} | " +
               $"📸 Екскурсії: {(SelectedExcursions.Count > 0 ? string.Join(", ", SelectedExcursions) : "немає")} | " +
               $"💵 Додаткові збори: {AdditionalCost} грн";
    }
}