using System;

namespace TravelAgency.Domain;

public class BookingEventArgs : EventArgs
{
    public Booking ConfirmedBooking { get; }

    public BookingEventArgs(Booking booking)
    {
        ConfirmedBooking = booking;
    }
}