namespace congestiontaxapi.models;

public class Bus : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return VehicleType.Bus;
    }
}
