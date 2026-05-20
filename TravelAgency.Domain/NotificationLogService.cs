using System;

namespace TravelAgency.Domain;

public class NotificationLogService
{
    public void OnBookingCreatedHandler(object? sender, BookingEventArgs e)
    {
        var booking = e.ConfirmedBooking;
        
        Console.WriteLine($"[NOTIFICATION SYSTEM] Успішно оформлено бронювання №{booking.Id}! " +
                          $"Клієнт: {booking.Tourist.Name}, Тур: '{booking.SelectedTour.Name}'. " +
                          $"Дата створення: {booking.BookingDate:dd.MM.yyyy HH:mm}");
    }
}