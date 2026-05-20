using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TravelAgency.Domain;

public class OptimizedStorage
{
    private readonly List<Client> _clientList = new();

    private readonly Dictionary<Guid, Client> _clientDictionary = new();

    public void AddClient(Client client)
    {
        _clientList.Add(client);
        _clientDictionary[client.Id] = client;
    }

    public string RunPerformanceTest()
    {
        Guid targetId = Guid.Empty;
        for (int i = 0; i < 100000; i++)
        {
            var c = new Client($"Турист {i}", $"tourist{i}@travel.com");
            AddClient(c);
            
            if (i == 95000) targetId = c.Id;
        }

        var stopwatch = Stopwatch.StartNew();
        var clientFromList = _clientList.FirstOrDefault(c => c.Id == targetId);
        stopwatch.Stop();
        long listTicks = stopwatch.ElapsedTicks;

        stopwatch.Restart();
        _clientDictionary.TryGetValue(targetId, out var clientFromDict);
        stopwatch.Stop();
        long dictTicks = stopwatch.ElapsedTicks;

        return $"[Тест СР6] Елементів: 100,000.\n" +
               $"Пошук у List<T>: {listTicks} тіків.\n" +
               $"Пошук у Dictionary: {dictTicks} тіків.\n" +
               $"Висновок: Словник працює значно швидше за рахунок Хеш-таблиці та пошуку за O(1)!";
    }
}