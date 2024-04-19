namespace congestiontaxapi.models;

public class Foreign : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return VehicleType.Foreign;
    }
}
