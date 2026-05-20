using System;

namespace TravelAgency.Domain;

public sealed class AgencyRegistry
{
    private static AgencyRegistry? _instance;
    private static readonly object _lock = new();

    public BookingService BookingService { get; }

    private AgencyRegistry()
    {
        BookingService = new BookingService();
    }

    public static AgencyRegistry Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AgencyRegistry();
                }
                return _instance;
            }
        }
    }
}