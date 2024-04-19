namespace congestiontaxapi.models;

public class Diplomat : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return VehicleType.Diplomat;
    }
}
