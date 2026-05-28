using System;
using System.Collections.Generic;
using System.Linq;
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
    public void PeakSeasonStrategy_ShouldApplyFifteenPercentMarkup()
    {
        decimal basePrice = 10000m;
        IPriceStrategy strategy = new PeakSeasonPriceStrategy();

        decimal finalPrice = strategy.CalculateFinalPrice(basePrice);

        Assert.Equal(11500m, finalPrice);
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
        Assert.Contains("Оглядова Париж", customTour.SelectedExcursions);
        Assert.Equal(9800m, customTour.AdditionalCost);
    }



    [Fact]
    public void FilterByCity_ShouldFindAndSortToursCorrectly()
    {
        var routeWithLviv = new Route() + "Київ" + "Львів" + "Прага";
        var routeWithoutLviv = new Route() + "Київ" + "Одеса" + "Стамбул";

        var tours = new List<Tour>
        {
            new Tour("Дорогий тур через Львів", 15000m, routeWithLviv),
            new Tour("Тур без Львова", 8000m, routeWithoutLviv),
            new Tour("Дешевий тур через Львів", 5000m, routeWithLviv)
        };

        var result = tours.FilterByCity("Львів").ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("Дешевий тур через Львів", result[0].Name);
    }


    [Fact]
    public void RouteIndexer_ShouldThrowException_WhenIndexIsOutOfBounds()
    {
        var route = new Route();
        route = route + "Київ" + "Париж";

        Assert.Throws<IndexOutOfRangeException>(() => {
            var city = route[5];
        });
    }
}