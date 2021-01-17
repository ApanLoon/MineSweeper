
public class MineField
{
    protected Sector[,,] Sectors;

    public MineField(int size)
    {
        Sectors = new Sector[size, size, size];
        for (int z = 0; z < size; z++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Sector sector = new Sector();

                    Sectors[x, y, z] = sector;
                }
            }
        }
    }
}
