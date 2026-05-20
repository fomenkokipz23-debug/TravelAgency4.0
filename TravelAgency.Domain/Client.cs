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
}