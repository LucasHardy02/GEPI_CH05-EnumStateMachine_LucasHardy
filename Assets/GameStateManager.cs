using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum GameState
{ 
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused    
}

public class GameStateManager : MonoBehaviour
{
    [SerializeField] UIManager UIManager;

    public GameState currentState { get; private set; }

    public GameState previousState { get; private set; }
   

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;
    private void Start()
    {
        SetState(GameState.Init);
    }
    private void Update()
    {
        ChangeState();
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        previousState = currentState;
        currentState = newState;
        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        //resets time scale incase game was paused last.
        Time.timeScale = 1;
        switch (newState)
        {

            case GameState.Init:
                Debug.Log($"Gamestate changed to Init");
                SetState(GameState.MainMenu);
                break;

            case GameState.Gameplay:
                Debug.Log($"Gamestate changed to Gameplay");
                UIManager.ShowGameplayUI();

                break;

            case GameState.Paused:
                Debug.Log($"Gamestate changed to Paused");
                UIManager.ShowPausedUI();
                Time.timeScale = 0;

                break;

            case GameState.MainMenu:
                Debug.Log($"Gamestate changed to Mainmenu");
                UIManager.ShowMainMenuUI();
                break;

            case GameState.None:
                Debug.Log("You should not be here, there is no gamestate.");
                break;

            default:
                break;
        }
    }
    private void ChangeState()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetState(GameState.None);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetState(GameState.Init);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetState(GameState.MainMenu);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetState(GameState.Gameplay);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           TogglePause();
        }
    }
    public void StartGame()
    {
        SetState(GameState.Gameplay);
    }  
    public void TogglePause()
    {
        if(currentState == GameState.Paused)
        {
            if (currentState == GameState.Gameplay) return;

            SetState(GameState.Gameplay);
        }

        else if (currentState == GameState.Gameplay)
        {
            if (currentState == GameState.Paused) return;

            SetState(GameState.Paused);
        }
    }
    public void MainMenuButton()
    {

        SetState(GameState.MainMenu);

    }
}


