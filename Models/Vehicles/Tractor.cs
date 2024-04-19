namespace congestiontaxapi.models;

public class Tractor : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return VehicleType.Tractor;
    }
}
