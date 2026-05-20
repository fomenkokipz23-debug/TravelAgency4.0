using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Domain;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly List<T> _storage = new();

    public void Add(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _storage.Add(entity);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _storage.AsReadOnly();
    }

    public T? Find(Func<T, bool> predicate)
    {
        return _storage.FirstOrDefault(predicate);
    }

    public void ExecuteForAll(Action<T> action)
    {
        foreach (var entity in _storage)
        {
            action(entity);
        }
    }
}