using System;
using System.IO;
using System.Text.Json;

namespace TravelAgency.Domain;

public class JsonDataSaver
{
    private readonly string _filePath = "booking_backup.json";

    public string SaveBookingState(Booking booking)
    {
        var dto = new BookingDto
        {
            BookingId = booking.Id.ToString(),
            ClientName = booking.Tourist.Name,
            TourName = booking.SelectedTour.Name,
            FinalPrice = booking.SelectedTour.GetPrice(), 
            FormattedDate = booking.BookingDate.ToString("yyyy-MM-dd HH:mm:ss")
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        
        string jsonString = JsonSerializer.Serialize(dto, options);
        
        File.WriteAllText(_filePath, jsonString);

        return jsonString;
    }
}