namespace congestiontaxapi.models;

public class Emergency : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return VehicleType.Emergency;
    }
}
