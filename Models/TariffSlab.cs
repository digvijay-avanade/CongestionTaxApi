namespace congestiontaxapi.models;

public class TariffSlab
{
    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public decimal Amount { get; set; }
}