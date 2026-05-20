using System.Collections.Generic;

namespace TravelAgency.Domain;

public interface ITourReader
{
    IReadOnlyList<Tour> GetAvailableTours();
}

public interface IBookingManager
{
    Booking CreateBooking(Client tourist, Tour tour);
    IReadOnlyList<Booking> GetActiveBookings();
}