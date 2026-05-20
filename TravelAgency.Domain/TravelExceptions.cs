using System;

namespace TravelAgency.Domain;

public class InvalidRouteException : Exception
{
    public int CurrentPlacesCount { get; }

    public InvalidRouteException(int currentPlacesCount) 
        : base($"Некоректний маршрут. Очікується мінімум 2 локації (старт і фініш), але знайдено лише {currentPlacesCount}.")
    {
        CurrentPlacesCount = currentPlacesCount;
    }
}

public class TravelServiceException : Exception
{
    public string FailedService { get; }

    public TravelServiceException(string serviceName, string message) 
        : base($"Помилка зовнішнього сервісу [{serviceName}]: {message}")
    {
        FailedService = serviceName;
    }
}