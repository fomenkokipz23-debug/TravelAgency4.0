using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Domain;

public class BookingService : ITourReader, IBookingManager
{
    private readonly List<Tour> _tours = new();
    private readonly List<Booking> _bookings = new();

    public event EventHandler<BookingEventArgs>? OnBookingCreated;

    public BookingService()
    {
        var route1 = new Route();
        route1 = route1 + "Київ" + "Львів" + "Париж";
        var tour1 = new Tour("Екскурсійний Париж (Стандарт)", 8500m, route1)
        {
            Description = "Класичний тур до серця Франції. Романтичні вулиці Монмартру, велична Ейфелева вежа та шедеври Лувру чекають на вас.",
            HotelImage3Star = "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?q=80&w=600&auto=format&fit=crop",
            HotelImage5Star = "https://images.unsplash.com/photo-1540541338287-41700207dee6?q=80&w=600&auto=format&fit=crop"
        };
        _tours.Add(tour1);

        var route2 = new Route();
        route2 = route2 + "Київ" + "Яремче" + "Буковель";
        var tour2 = new CulinaryTour("Гастро-тур у Карпати (Акція)", 4000m, route2, tastingsCount: 3, pricePerTasting: 200m)
        {
            Description = "Смачні традиційні страви, чисте гірське повітря та неймовірні краєвиди Карпатських гір зі знижкою.",
            HotelImage3Star = "https://images.unsplash.com/photo-1596394516093-501ba68a0ba6?q=80&w=600&auto=format&fit=crop",
            HotelImage5Star = "https://images.unsplash.com/photo-1566073771259-6a8506099945?q=80&w=600&auto=format&fit=crop"
        };
        _tours.Add(tour2);

        var route3 = new Route();
        route3 = route3 + "Львів" + "Ужгород" + "Прага";
        var tour3 = new Tour("Вікенд у Празі (Стандарт)", 5200m, route3)
        {
            Description = "Затишна подорож старовинними вуличками Праги. Готична архітектура, Карлів міст та знаменита чеська гостинність.",
            HotelImage3Star = "https://images.unsplash.com/photo-1551882547-ff40c63fe5fa?q=80&w=600&auto=format&fit=crop",
            HotelImage5Star = "https://images.unsplash.com/photo-1571896349842-33c89424de2d?q=80&w=600&auto=format&fit=crop"
        };
        _tours.Add(tour3);

        var route4 = new Route();
        route4 = route4 + "Київ" + "Відень" + "Інсбрук";
        var tour4 = new AdventureTour("Альпійський Експрес (Сезонний пік)", 12000m, route4, hazardInsuranceFee: 1500m)
        {
            Description = "Тур для поціновувачів активного відпочинку та засніжених вершин. Панорамні поїзди та австрійський затишок.",
            HotelImage3Star = "https://images.unsplash.com/photo-1445019980597-93fa8acb246c?q=80&w=600&auto=format&fit=crop",
            HotelImage5Star = "https://images.unsplash.com/photo-1544161515-4ab6ce6db874?q=80&w=600&auto=format&fit=crop"
        };
        _tours.Add(tour4);
    }

    public IReadOnlyList<Tour> GetAvailableTours()
    {
        return _tours.AsReadOnly();
    }

    public Booking CreateBooking(Client tourist, Tour tour)
    {
        var booking = new Booking(tourist, tour);
        _bookings.Add(booking);
        
        OnBookingCreated?.Invoke(this, new BookingEventArgs(booking));
        return booking;
    }

    public IReadOnlyList<Booking> GetActiveBookings()
    {
        return _bookings.AsReadOnly();
    }

    public void CancelBooking(Guid bookingId)
    {
        var bookingToRemove = _bookings.FirstOrDefault(b => b.Id == bookingId);
        if (bookingToRemove != null)
        {
            _bookings.Remove(bookingToRemove);
        }
    }
}