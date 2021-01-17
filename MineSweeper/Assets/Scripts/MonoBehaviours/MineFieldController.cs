using UnityEngine;

public class MineFieldController : MonoBehaviour
{
    [SerializeField] protected float SectorSize = 10f;
    [SerializeField] protected GameObject SectorPrefab;

    protected MineField MineField;
    protected SectorController[,,] SectorControllers;

    private void Start()
    {
        GameEventManager.Instance.OnMineFieldCreated += OnMineFieldCreated;
    }

    protected void OnMineFieldCreated(MineField mineField)
    {
        if (SectorControllers != null)
        {
            DestroyMineField();
        }

        MineField = mineField;
        BuildMineField();
    }

    protected void BuildMineField()
    {
        SectorControllers = new SectorController[MineField.SectorsPerEdge, MineField.SectorsPerEdge, MineField.SectorsPerEdge];
        for (int z = 0; z < MineField.SectorsPerEdge; z++)
        {
            for (int y = 0; y < MineField.SectorsPerEdge; y++)
            {
                for (int x = 0; x < MineField.SectorsPerEdge; x++)
                {
                    GameObject go = Instantiate (SectorPrefab, transform);

                    go.transform.position = new Vector3 (x * SectorSize, y * SectorSize, z * SectorSize);
                    go.name = $"Sector {MineField.Sectors[x, y, z].FieldPosition}";

                    SectorController controller = go.GetComponent<SectorController>();
                    if (controller == null)
                    {
                        Debug.LogError("MineFieldController.BuildMineField: Sector prefab has no SectorController.");
                    }

                    SectorControllers[x, y, z] = controller;
                }
            }
        }

        SectorControllers = null;
    }

    protected void DestroyMineField()
    {
        for (int z = 0; z < MineField.SectorsPerEdge; z++)
        {
            for (int y = 0; y < MineField.SectorsPerEdge; y++)
            {
                for (int x = 0; x < MineField.SectorsPerEdge; x++)
                {
                    if (SectorControllers[x, y, z] != null)
                    {
                        Destroy(SectorControllers[x, y, z].gameObject);
                    }
                }
            }
        }

        SectorControllers = null;
    }
}
