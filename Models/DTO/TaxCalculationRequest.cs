namespace congestiontaxapi.models;

public class TaxCalculationRequest
{
    public VehicleType VehicleType { get; set; }
    public List<DateTime> DateTimes { get; set; } = new List<DateTime>();
}
