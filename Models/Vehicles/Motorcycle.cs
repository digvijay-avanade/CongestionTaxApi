namespace congestiontaxapi.models;

public class Motorcycle : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return VehicleType.Motorcycle;
    }
}
