using congestiontaxapi.models;


namespace congestiontaxapi.services;

public interface ICalculatorService
{
    decimal CalculateTax(VehicleType vehicle, List<DateTime> dateTimes);
}
