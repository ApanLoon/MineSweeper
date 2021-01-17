using UnityEngine;


public enum GameState
{
    Menu,
    Playing,
    Win,
    Lose
}

public class GameController : MonoBehaviour
{
    public GameState GameState { get; protected set; } = GameState.Menu;

    [SerializeField]protected PlayerController Player0;

    protected MineField MineField;

    public void NewGame()
    {
        MineField = new MineField(10, 10);

        Player0.transform.position = new Vector3(5 * 10f, 5 * 10f, -100f); // TODO: The scale factor is in MineFieldController, should it be?

        GameState = GameState.Playing;
        GameEventManager.Instance.RaiseOnGameStateChanged (GameState);
    }
}
