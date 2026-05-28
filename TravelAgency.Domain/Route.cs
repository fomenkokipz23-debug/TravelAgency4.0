using System;
using System.Collections.Generic;

namespace TravelAgency.Domain;

public class Route
{
    private readonly List<string> _cities = new();

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= _cities.Count)
                throw new IndexOutOfRangeException("Вказаного міста немає в маршруті.");
            return _cities[index];
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва міста не може бути порожньою.");
            if (index < 0 || index >= _cities.Count)
                throw new IndexOutOfRangeException("Некоректний індекс для зміни міста.");
            _cities[index] = value;
        }
    }

    public int PlacesCount => _cities.Count;

    public IReadOnlyList<string> Cities => _cities;

    public static Route operator +(Route currentRoute, string newCity)
    {
        if (string.IsNullOrWhiteSpace(newCity)) return currentRoute;

        currentRoute._cities.Add(newCity);
        return currentRoute;
    }

    public string GetFullRouteString()
    {
        return _cities.Count == 0 ? "Маршрут порожній" : string.Join(" ➢ ", _cities);
    }
}