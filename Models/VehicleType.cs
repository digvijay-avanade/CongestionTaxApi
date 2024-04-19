namespace congestiontaxapi.models;

/// <summary>
/// All Vehicle Types.
/// </summary>
public enum VehicleType
{
    /// <summary>
    /// The vehicles with type others can be taxed. Others are exempt.
    /// </summary>
    Others = 0,

    /// <summary>
    /// Not taxed
    /// </summary>
    Motorcycle,
    Tractor,
    Emergency,
    Diplomat,
    Foreign,
    Military,
    Bus
}