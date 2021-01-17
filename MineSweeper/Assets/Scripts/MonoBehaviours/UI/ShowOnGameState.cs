using UnityEngine;

[RequireComponent (typeof (CanvasGroup))]
public class ShowOnGameState : MonoBehaviour
{
    [SerializeField] protected GameState ShowOnState;

    protected CanvasGroup CanvasGroup;

    private void Start()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        GameEventManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    protected void OnGameStateChanged (GameState gameState)
    {
        if (gameState == ShowOnState)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    protected void Show()
    {
        CanvasGroup.alpha = 1f;
        CanvasGroup.blocksRaycasts = true;
    }

    protected void Hide()
    {
        CanvasGroup.alpha = 0f;
        CanvasGroup.blocksRaycasts = false;
    }
}
