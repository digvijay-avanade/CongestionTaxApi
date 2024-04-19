using congestiontaxapi.models;
using Microsoft.Extensions.Options;

namespace congestiontaxapi.services;

public class CalculatorService : ICalculatorService
{
    private readonly ILogger<CalculatorService> _logger;
    private readonly IOptions<TariffRules> _tariffRules;


    public CalculatorService(ILogger<CalculatorService> logger, IOptions<TariffRules> tarrifRules)
    {
        _logger = logger;
        _tariffRules = tarrifRules;
    }


    public decimal CalculateTax(VehicleType vehicleType, List<DateTime> dateTimes)
    {
        _logger.LogDebug($"Calculating tax for {vehicleType} for given dates {dateTimes} ...");
        var dateTimesSorted = from m in dateTimes
                              orderby m ascending
                              select m;

        var dateTimeGroups = new Dictionary<DateOnly, List<DateTime>>();

        foreach (var date in dateTimesSorted)
        {
            var key = DateOnly.FromDateTime(date);
            if (dateTimeGroups.ContainsKey(key))
            {
                dateTimeGroups[key].Add(date);
            }
            else
            {
                dateTimeGroups.Add(key, new List<DateTime>() { date });
            }
        }

        _logger.LogDebug($"The given dates have {dateTimeGroups.Keys.Count} unique dates ...");

        decimal totalFee = 0;

        foreach (var item in dateTimeGroups.Values)
        {
            decimal dayFee = 0;
            DateTime intervalStart = item.First();

            foreach (DateTime date in item)
            {
                if (_tariffRules.Value.SingleChargeRuleApplicable)
                {
                    decimal nextFee = GetTollFee(date, vehicleType);
                    decimal tempFee = GetTollFee(intervalStart, vehicleType);

                    long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                    long minutes = diffInMillies / 1000 / 60;

                    if (minutes <= _tariffRules.Value.SingleChargeWindowDuration.Minutes)
                    {
                        if (dayFee > 0) dayFee -= tempFee;
                        if (nextFee >= tempFee) tempFee = nextFee;
                        dayFee += tempFee;
                    }
                    else
                    {
                        dayFee += nextFee;
                    }

                    intervalStart = date;
                }
                else
                {
                    decimal nextFee = GetTollFee(date, vehicleType);
                    dayFee += nextFee;
                }
            }
            if (dayFee > _tariffRules.Value.MaxTariffPerDay)
            {
                dayFee = _tariffRules.Value.MaxTariffPerDay;
            }

            totalFee += dayFee;

            _logger.LogDebug($"The fee for date {DateOnly.FromDateTime(intervalStart)} is {dayFee}. Total has reached {totalFee}");

        }

        _logger.LogDebug($"The total fee for all {dateTimeGroups.Keys.Count} dates is {totalFee}.");
        return totalFee;
    }

    public decimal GetTollFee(DateTime date, VehicleType vehicleType)
    {
        if (IsTollFreeDate(date) || vehicleType.IsTollFreeVehicle()) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        var timeOnly = new TimeOnly(hour, minute);
        foreach (TariffSlab slab in _tariffRules.Value.TariffSlabs)
        {
            if (timeOnly.IsBetween(slab.StartTime, slab.EndTime))
                return slab.Amount;
        }

        return 0;

    }

    private bool IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (_tariffRules.Value.IsWeekendExempt && (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)) return true;

        if (_tariffRules.Value.ExemptMonths != null &&
            _tariffRules.Value.ExemptMonths.Count > 0 &&
            _tariffRules.Value.ExemptMonths.Contains(month))
        {
            return true;
        }

        if (_tariffRules.Value.ExemptDates != null &&
            _tariffRules.Value.ExemptDates.Count > 0 &&
            _tariffRules.Value.ExemptDates.Contains(new DateOnly(year, month, day)))
        {
            return true;
        }

        return false;
    }

}
