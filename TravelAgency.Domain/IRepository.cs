using System;
using System.Collections.Generic;

namespace TravelAgency.Domain;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    IReadOnlyList<T> GetAll();
    
    T? Find(Func<T, bool> predicate);
    
    void ExecuteForAll(Action<T> action);
}