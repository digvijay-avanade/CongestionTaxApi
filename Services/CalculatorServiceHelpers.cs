using congestiontaxapi.models;

namespace congestiontaxapi.services
{
    public static class CalculatorServiceHelpers
    {

        public static bool IsTollFreeVehicle(this VehicleType vehicleType)
        {
            return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Bus.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Military.ToString());
        }
    }
}