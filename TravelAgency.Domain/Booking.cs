using System;

namespace TravelAgency.Domain;

public class Booking : IDisposable
{
    public Guid Id { get; private set; }
    public Client Tourist { get; private set; }
    public Tour SelectedTour { get; private set; }
    public DateTime BookingDate { get; private set; }
    private bool _isDisposed = false;

    public Booking(Client tourist, Tour selectedTour)
    {
        Id = Guid.NewGuid();
        Tourist = new Client(tourist);
        SelectedTour = new Tour(selectedTour);
        BookingDate = DateTime.Now;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
            }
            _isDisposed = true;
        }
    }

    ~Booking()
    {
        Dispose(false);
    }
}