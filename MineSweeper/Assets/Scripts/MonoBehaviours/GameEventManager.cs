using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public event Action<MineField> OnMineFieldCreated;

    public void RaiseOnMineFieldCreated(MineField mineField)
    {
        OnMineFieldCreated?.Invoke (mineField);
    }
}
