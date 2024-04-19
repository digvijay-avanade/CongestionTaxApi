namespace congestiontaxapi.models;

public class TariffRules
{
    /// <summary>
    /// The city name for - if we need elsewhere.
    /// </summary>
    public string City { get; set; } = "Göteborg";

    /// <summary>
    /// The currency name for currency units - if we need elsewhere.
    /// </summary>
    public string Currency { get; set; } = "SEK";


    /// <summary>
    /// The maximum amount that can be charged per day. Default value is 60 Currency Units.
    /// </summary>
    public decimal MaxTariffPerDay { get; set; } = 60;

    /// <summary>
    /// A flag indicating if tool is charged on weekends. Default is false.
    /// </summary>
    public bool IsWeekendExempt { get; set; } = true;

    /// <summary>
    /// List of exempted dates - e.g. Public Holidays, Bank Holidays etc.
    /// </summary>
    public List<DateOnly> ExemptDates { get; set; } = new List<DateOnly>();

    /// <summary>
    /// The months numbers where no congestion tax is charged. Month numbers are 1-12 only. By default July is exempt.
    /// </summary>
    public List<int> ExemptMonths { get; set; } = new List<int>() { 7 };

    /// <summary>
    /// Flag indicating If the single charge rule applies. Default is true.
    /// </summary>
    public bool SingleChargeRuleApplicable { get; set; } = true;

    /// <summary>
    /// The length of the Single charge window. Can be caliberated as needed but the default is 1 hour.
    /// </summary>
    public TimeSpan SingleChargeWindowDuration { get; set; } = TimeSpan.FromHours(1);

    public List<TariffSlab> TariffSlabs { get; set; } = new List<TariffSlab>()
    {
        new TariffSlab() { StartTime = new TimeOnly(6,0) , EndTime = new TimeOnly(6,29), Amount = 8 },
        new TariffSlab() { StartTime = new TimeOnly(6,30) , EndTime = new TimeOnly(6,59), Amount = 13 },
        new TariffSlab() { StartTime = new TimeOnly(7,0) , EndTime = new TimeOnly(7,59), Amount = 18 },
        new TariffSlab() { StartTime = new TimeOnly(8,0) , EndTime = new TimeOnly(8,29), Amount = 13 },
        new TariffSlab() { StartTime = new TimeOnly(8,30) , EndTime = new TimeOnly(14,59), Amount = 8 },
        new TariffSlab() { StartTime = new TimeOnly(15,0) , EndTime = new TimeOnly(15,29), Amount = 13 },
        new TariffSlab() { StartTime = new TimeOnly(15,30) , EndTime = new TimeOnly(16,59), Amount = 18 },
        new TariffSlab() { StartTime = new TimeOnly(17,0) , EndTime = new TimeOnly(17,59), Amount = 13 },
        new TariffSlab() { StartTime = new TimeOnly(18,0) , EndTime = new TimeOnly(18,29), Amount = 8 },
        new TariffSlab() { StartTime = new TimeOnly(18,30) , EndTime = new TimeOnly(5,59), Amount = 0 }
    };
}
