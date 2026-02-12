using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject gameOverUI;

    public void ShowMainMenuUI()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }
    public void ShowGameplayUI()
    {
        HideAllUI();
        gameplayUI.SetActive(true);
    }
    public void ShowPausedUI()
    {
        HideAllUI();
        gameplayUI.SetActive(true);
        pausedUI.SetActive(true);
    }

    public void HideAllUI()
    {
        gameplayUI.SetActive(false);
        mainMenuUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        optionsUI.SetActive(false);
    }
    public void ShowOptionsUI()
    {
        HideAllUI();
        optionsUI.SetActive(true);
    }
    public void GameOverUI()
    {
        HideAllUI();
        gameOverUI.SetActive(true);
    }


}
