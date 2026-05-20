namespace TravelAgency.Domain;

public class AdventureTour : Tour
{
    public decimal HazardInsuranceFee { get; set; }

    public AdventureTour(string name, decimal basePrice, Route route, decimal hazardInsuranceFee)
        : base(name, basePrice, route)
    {
        HazardInsuranceFee = hazardInsuranceFee;
    }

    public override decimal GetPrice()
    {
        return BasePrice + HazardInsuranceFee;
    }

    public new string GetTourTypeInfo()
    {
        return $"[Adventure Tour] Увага! Цей тур містить елементи екстриму. Страховий внесок: {HazardInsuranceFee} грн.";
    }
}