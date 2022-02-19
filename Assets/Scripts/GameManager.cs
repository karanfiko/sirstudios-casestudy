using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        UpdateGameState(GameState.Started);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.Started:
                TouchManager.instance.isActive = false;
                UIManager.instance.ToggleStartMenu(true);
                UIManager.instance.SetCurrentScoreText(0);
                break;
            case GameState.Gameplay:
                TouchManager.instance.isActive = true;
                UIManager.instance.ToggleStartMenu(false);
                break;
            case GameState.Finish:
                TouchManager.instance.isActive = false;
                UIManager.instance.ToggleFinishMenu(true);
                break;
            default:
                Debug.LogError("UndefineState"); 
                break;

        }
    }
}
public enum GameState
{
    Started,
    Gameplay,
    Finish
}