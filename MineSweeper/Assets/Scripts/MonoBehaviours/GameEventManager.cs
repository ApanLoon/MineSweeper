using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; protected set; }

    private void Awake()
    {
        if (Instance != null)
        {
            if (Instance == this)
            {
                return;
            }
            Debug.LogError($"GameEventManager: Multiple managers in scene, disabling {name}");
            enabled = false;
            return;
        }
        Instance = this;
    }

    public event Action<MineField> OnMineFieldCreated;
    public void RaiseOnMineFieldCreated (MineField mineField)
    {
        OnMineFieldCreated?.Invoke (mineField);
    }

    public event Action<GameState> OnGameStateChanged;
    public void RaiseOnGameStateChanged (GameState gameState)
    {
        OnGameStateChanged?.Invoke (gameState);
    }

}
