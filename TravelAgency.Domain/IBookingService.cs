using System;
using System.Collections.Generic;

namespace TravelAgency.Domain;

public interface IBookingService
{
    IReadOnlyList<Tour> GetAvailableTours();
    
    Booking CreateBooking(Client tourist, Tour tour);
    
    IReadOnlyList<Booking> GetActiveBookings();
}