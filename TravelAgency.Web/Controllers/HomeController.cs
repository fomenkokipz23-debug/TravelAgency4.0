using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelAgency.Domain;

namespace TravelAgency.Web.Controllers;

public class HomeController : Controller
{
    private readonly ITourReader _tourReader;

    public HomeController(ITourReader tourReader)
    {
        _tourReader = tourReader;
    }

    public IActionResult Index()
    {
        var tours = _tourReader.GetAvailableTours();
        return View(tours);
    }

    public IActionResult Details(string tourName)
    {
        var tours = _tourReader.GetAvailableTours();
        var tour = tours.FirstOrDefault(t => t.Name == tourName);
        if (tour == null) return NotFound();

        IPriceStrategy priceStrategy = new StandardPriceStrategy();
        string nameLower = tour.Name.ToLower();
        if (nameLower.Contains("акція") || nameLower.Contains("гарячий")) priceStrategy = new HotTourPriceStrategy();
        else if (nameLower.Contains("пік") || nameLower.Contains("сезонний")) priceStrategy = new PeakSeasonPriceStrategy();

        ViewBag.CalculatedBasePrice = priceStrategy.CalculateFinalPrice(tour.BasePrice);
        return View(tour);
    }

    [Authorize] 
    [HttpPost]
    public IActionResult BuildTrip(string tourName, string flightClass, string hotelStars, string withExcursion, string formattedDeparture, string formattedArrival)
    {
        var tours = _tourReader.GetAvailableTours();
        var baseTour = tours.FirstOrDefault(t => t.Name == tourName);
        if (baseTour == null) return NotFound();

        IPriceStrategy priceStrategy = new StandardPriceStrategy();
        string tariffLogName = "Стандартний тариф";
        string nameLower = baseTour.Name.ToLower();

        if (nameLower.Contains("акція") || nameLower.Contains("гарячий"))
        {
            priceStrategy = new HotTourPriceStrategy(); 
            tariffLogName = "Акційна пропозиція (Знижка 20%)";
        }
        else if (nameLower.Contains("пік") || nameLower.Contains("сезонний"))
        {
            priceStrategy = new PeakSeasonPriceStrategy(); 
            tariffLogName = "Сезонний тариф (Націнка 15%)";
        }

        decimal tourPriceAfterStrategy = priceStrategy.CalculateFinalPrice(baseTour.BasePrice);

        var builder = new ComplexTourBuilder();
        builder.StartNewBuild();

        if (flightClass == "Comfort") builder.BuildFlight("Комфорт-клас", 3500m);
        else builder.BuildFlight("Стандарт-клас", 0m); 

        if (hotelStars == "3Star") builder.BuildHotel("Готель 3* (Стандарт)", 1800m);
        else if (hotelStars == "5Star") builder.BuildHotel("Готель 5* (Преміум)", 4500m);

        if (withExcursion == "Yes") builder.AddExcursion("Повний пакет екскурсій", 1200m);

        var customTour = builder.Build();
        decimal totalSummaryCost = tourPriceAfterStrategy + customTour.AdditionalCost;
        string currentUserName = User.Identity!.Name!;

        string currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value ?? "user@email.com";
        var clientObj = new Client(currentUserName, currentUserEmail);
        var finalizedTour = new Tour($"{baseTour.Name} [Період: {formattedDeparture} - {formattedArrival}] ({customTour.GetSummary()})", totalSummaryCost, baseTour.TourRoute);
        AgencyRegistry.Instance.BookingService.CreateBooking(clientObj, finalizedTour);

        ViewBag.TourName = baseTour.Name;
        ViewBag.Route = baseTour.TourRoute.GetFullRouteString();
        ViewBag.TariffName = tariffLogName;
        ViewBag.BuilderDetails = customTour.GetSummary();
        ViewBag.TotalCost = totalSummaryCost;
        ViewBag.ClientNameForReceipt = currentUserName; 
        ViewBag.DepartureDate = formattedDeparture;
        ViewBag.ArrivalDate = formattedArrival;

        return View("Result");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}