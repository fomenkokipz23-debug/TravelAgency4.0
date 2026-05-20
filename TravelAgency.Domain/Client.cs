using System;

namespace TravelAgency.Domain;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Client()
    {
        Id = Guid.NewGuid();
        Name = "Анонімний Турист";
        Email = "anonymous@travel.com";
    }

    public Client(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public Client(Client other)
    {
        Id = other.Id;
        Name = other.Name;
        Email = other.Email;
    }

    public static bool operator ==(Client? left, Client? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Email.Equals(right.Email, StringComparison.OrdinalIgnoreCase);
    }

    public static bool operator !=(Client? left, Client? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is Client client && this == client;
    }

    public override int GetHashCode()
    {
        return Email.GetHashCode();
    }
}