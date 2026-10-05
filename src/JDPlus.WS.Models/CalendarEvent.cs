namespace JDPlus.WS.Models;

public enum CalendarEvent
{
    Unspecified = 0,

    /// <summary>
    /// January, 1
    /// </summary>
    NewYear = 1,

    /// <summary>
    /// Shrove Monday (48 days before Easter)
    /// </summary>
    ShroveMonday = 2,

    /// <summary>
    /// Shrove Tuesday (47 days before Easter)
    /// </summary>
    ShroveTuesday = 3,

    /// <summary>
    /// Ash Wednesday (46 days before Easter)
    /// </summary>
    AshWednesday = 4,

    /// <summary>
    /// Easter
    /// </summary>
    Easter = 5,

    /// <summary>
    /// Julian Easter.
    /// </summary>
    JulianEaster = 6,

    /// <summary>
    /// Last Thursday before Easter
    /// </summary>
    MaundyThursday = 7,

    /// <summary>
    /// Last Friday before Easter
    /// </summary>
    GoodFriday = 8,

    /// <summary>
    /// First Monday after Easter
    /// </summary>
    EasterMonday = 9,

    /// <summary>
    /// Ascension (40 days after Easter)
    /// </summary>
    Ascension = 10,

    /// <summary>
    /// Pentecost (50 days after Easter)
    /// </summary>
    Pentecost = 11,

    /// <summary>
    /// Corpus Christi (60 days after Easter)
    /// </summary>
    CorpusChristi = 12,

    /// <summary>
    /// First Monday after Pentecost (50 days after Easter)
    /// </summary>
    WhitMonday = 13,

    /// <summary>
    /// May, 1
    /// </summary>
    MayDay = 14,

    /// <summary>
    /// August, 15
    /// </summary>
    Assumption = 15,

    /// <summary>
    /// Second Tuesday of September
    /// </summary>
    LaborDay = 16,

    /// <summary>
    /// October, 31
    /// </summary>
    Halloween = 17,

    /// <summary>
    /// November, 1
    /// </summary>
    AllSaintsDay = 18,

    /// <summary>
    /// November, 11
    /// </summary>
    Armistice = 19,

    /// <summary>
    /// Fourth Thursday of November
    /// </summary>
    Thanksgiving = 20,

    /// <summary>
    /// December, 25
    /// </summary>
    Christmas = 21,
}
