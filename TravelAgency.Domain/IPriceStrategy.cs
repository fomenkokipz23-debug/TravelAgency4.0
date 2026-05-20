namespace TravelAgency.Domain;

public interface IPriceStrategy
{
    decimal CalculateFinalPrice(decimal basePrice);
}

public class StandardPriceStrategy : IPriceStrategy
{
    public decimal CalculateFinalPrice(decimal basePrice) => basePrice;
}

public class HotTourPriceStrategy : IPriceStrategy
{
    public decimal CalculateFinalPrice(decimal basePrice) => basePrice * 0.8m;
}

public class PeakSeasonPriceStrategy : IPriceStrategy
{
    public decimal CalculateFinalPrice(decimal basePrice) => basePrice * 1.15m;
}