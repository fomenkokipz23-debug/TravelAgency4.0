using System;

namespace TravelAgency.Domain;

public class BookingDto
{
    public string BookingId { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string TourName { get; set; } = string.Empty;
    public decimal FinalPrice { get; set; }
    public string FormattedDate { get; set; } = string.Empty;
}