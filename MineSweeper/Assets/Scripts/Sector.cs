using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Sector
{
    /// <summary>
    /// Position in the field grid
    /// </summary>
    public Vector3Int FieldPosition { get; protected set; }

    /// <summary>
    /// True if this sector actually has a mine
    /// </summary>
    public bool HasMine { get; set; }

    /// <summary>
    /// True if this sector has been marked as containing a mine
    /// </summary>
    public bool IsShielded { get; set; }

    public Sector (Vector3Int fieldPosition)
    {
        FieldPosition = fieldPosition;
    }
}
