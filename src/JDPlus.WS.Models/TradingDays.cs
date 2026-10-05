namespace JDPlus.WS.Models;

public enum TradingDays
{
    TDNone = 0,

    /// <summary>
    /// MON-FRI + SAT-SUN
    /// </summary>
    TD2 = 1,

    /// <summary>
    /// MON-SAT + SUN
    /// </summary>
    TD2C = 2,

    /// <summary>
    /// MON-FRI + SAT + SUN
    /// </summary>
    TD3 = 3,

    /// <summary>
    /// MON-THU + FRI-SAT + SUN
    /// </summary>
    TD3C = 4,

    /// <summary>
    /// MON-THU + FRI + SAT + SUN
    /// </summary>
    TD4 = 5,
    TD7 = 6
}
