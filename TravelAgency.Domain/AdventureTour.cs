namespace TravelAgency.Domain;

public class AdventureTour : Tour
{
    public decimal HazardInsuranceFee { get; set; }

    public AdventureTour(string name, decimal basePrice, Route tourRoute, decimal hazardInsuranceFee) 
        : base(name, basePrice, tourRoute)
    {
        HazardInsuranceFee = hazardInsuranceFee;
    }
}