using System;
using System.Collections.Generic;

namespace TravelAgency.Domain;

public class BookingService : ITourReader, IBookingManager
{
    private readonly List<Tour> _tours = new();
    private readonly List<Booking> _bookings = new();

    public event EventHandler<BookingEventArgs>? OnBookingCreated;

    public BookingService()
    {
        var route1 = new Route();
        route1 = route1 + "Київ" + "Львів" + "Краків" + "Париж";

        var route2 = new Route();
        route2 = route2 + "Київ" + "Яремче" + "Буковель";

        _tours.Add(new Tour("Екскурсійний Париж", 8500m, route1));
        _tours.Add(new CulinaryTour("Гастро-тур у Карпати", 4000m, route2, tastingsCount: 3, pricePerTasting: 300m));
    }

    public IReadOnlyList<Tour> GetAvailableTours()
    {
        return _tours.AsReadOnly();
    }

    public Booking CreateBooking(Client tourist, Tour tour)
    {
        if (tour.TourRoute.PlacesCount < 2)
            throw new InvalidRouteException(tour.TourRoute.PlacesCount);

        var booking = new Booking(tourist, tour);
        _bookings.Add(booking);

        OnBookingCreated?.Invoke(this, new BookingEventArgs(booking));

        return booking;
    }

    public IReadOnlyList<Booking> GetActiveBookings()
    {
        return _bookings.AsReadOnly();
    }
}