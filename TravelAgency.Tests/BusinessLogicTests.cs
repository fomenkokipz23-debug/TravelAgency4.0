using System;
using System.Collections.Generic;
using TravelAgency.Domain;
using Xunit;

namespace TravelAgency.Tests;

public class BusinessLogicTests
{
    [Fact]
    public void HotTourStrategy_ShouldApplyTwentyPercentDiscount()
    {
        decimal basePrice = 10000m;
        IPriceStrategy strategy = new HotTourPriceStrategy();

        decimal finalPrice = strategy.CalculateFinalPrice(basePrice);

        Assert.Equal(8000m, finalPrice);
    }

    [Fact]
    public void ComplexTourBuilder_ShouldAssembleTourCorrectly()
    {
        var builder = new ComplexTourBuilder();

        var customTour = builder.StartNewBuild()
            .BuildFlight("Бізнес", 5000m)
            .BuildHotel("Преміум Готель 5*", 4000m)
            .AddExcursion("Оглядова Париж", 800m)
            .Build();

        Assert.Equal("Бізнес клас", customTour.FlightDetails);
        Assert.Equal("Преміум Готель 5*", customTour.HotelDetails);
        Assert.Single(customTour.SelectedExcursions);
        Assert.Equal(9800m, customTour.AdditionalCost);
    }
}