namespace congestiontaxapi.models;

public class Car : IVehicle
{
    public VehicleType GetVehicleType()
    {
        return  VehicleType.Others;
    }
}
