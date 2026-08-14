namespace JDPlus.WS.Models;

public enum ParameterType
{
    /// <summary>
    /// Similar to null
    /// </summary>
    Unused = 0,

    /// <summary>
    /// Parameter is used but not defined (to be estimated)
    /// </summary>
    Undefined = 1,
    Fixed = 2,
    Initial = 3,
    Estimated = 4,
}
