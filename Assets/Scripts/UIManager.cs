using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject GameplayMenu;
    [SerializeField] private GameObject FinishMenu;
    [SerializeField] private TextMeshProUGUI textCurrentScore;
    [SerializeField] private TextMeshProUGUI textTotalScore;

    public static UIManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void SetCurrentScoreText(int newValue)
    {
        textCurrentScore.text = "Score = " + newValue.ToString();
    }

    public void SetTotalScoreText(int newValue)
    {
        textTotalScore.text = "Score = " + newValue.ToString();
    }

    public void ToggleStartMenu(bool dec)
    {
        StartMenu.SetActive(dec);
        GameplayMenu.SetActive(!dec);
    }

    public void ToggleFinishMenu(bool dec)
    {
        GameplayMenu.SetActive(!dec);
        FinishMenu.SetActive(dec);
    }

    public void ButtonStart()
    {
        GameManager.instance.UpdateGameState(GameState.Gameplay);
    }

    public void ButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
