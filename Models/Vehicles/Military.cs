namespace congestiontaxapi.models;

public class Military : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return VehicleType.Military;
    }
}
