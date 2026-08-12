namespace JDPlus.WS.Models;

public enum Frequency
{
    /// <summary>
    /// Undefined frequency. To be used when the frequency of an event is unknown.
    /// </summary>
    Undefined = 0,

    /// <summary>
    /// One event by year
    /// </summary>
    Yearly = 1,

    /// <summary>
    /// One event every half-year
    /// </summary>
    HalfYearly = 2,

    /// <summary>
    /// One event every four months
    /// </summary>
    QuadriMonthly = 3,

    /// <summary>
    /// One event every quarter
    /// </summary>
    Quarterly = 4,

    /// <summary>
    /// One event every two months
    /// </summary>
    BiMonthly = 6,

    /// <summary>
    /// One event every month
    /// </summary>
    Monthly = 12
}
