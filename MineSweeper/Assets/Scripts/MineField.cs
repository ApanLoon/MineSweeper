
using UnityEngine;

public class MineField
{
    public int SectorsPerEdge { get; protected set; }
    public int MineCount { get; protected set; }

    public Sector[,,] Sectors { get; protected set; }

    public MineField (int sectorsPerEdge, int mineCount)
    {
        SectorsPerEdge = sectorsPerEdge;
        Sectors = new Sector[sectorsPerEdge, sectorsPerEdge, sectorsPerEdge];
        MineCount = mineCount;

        for (int z = 0; z < sectorsPerEdge; z++)
        {
            for (int y = 0; y < sectorsPerEdge; y++)
            {
                for (int x = 0; x < sectorsPerEdge; x++)
                {
                    Sector sector = new Sector(new Vector3Int (x, y, z));
                    Sectors[x, y, z] = sector;
                }
            }
        }

        for (int i = 0; i < MineCount; i++)
        {
            Sector sector;
            do
            {
                sector = Sectors[Random.Range(0, sectorsPerEdge), Random.Range(0, sectorsPerEdge), Random.Range(0, sectorsPerEdge)];
            } while (sector.HasMine);

            sector.HasMine = true;
        }

        GameEventManager.Instance.RaiseOnMineFieldCreated (this);
    }
}
