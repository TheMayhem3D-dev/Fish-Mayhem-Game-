using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Active,
    Pause,
    Win,
    Loose,
    Tutorial
}

public class GameStateController : MonoBehaviour
{
    //[Header("GameState")]
    //[SerializeField] private GameState gameState = GameState.Active;

    void Start()
    {
        ChangeGameState(GameState.Tutorial);
    }

    public void ChangeGameState(GameState value)
    {
        switch (value)
        {
            case GameState.Active:
                //GameController.instance.CursorController.ChangeCursor(GameController.instance.CursorController.CombatCursorIndex);
                GameController.instance.EnablePlayer(true);
                GameController.instance.UserInterface.PauseMenu.SetActive(false);
                GameController.instance.UserInterface.TutorialMenu.SetActive(false);
                GameController.instance.EnableTime(true);
                break;

            case GameState.Pause:
                GameController.instance.EnablePlayer(false);
                Pause();
                goto default;

            case GameState.Win:
                Win();
                goto default;

            case GameState.Loose:
                Loose();
                break;

            case GameState.Tutorial:
                ShowTutorial();
                goto default;

            default:
                //GameController.instance.CursorController.ChangeCursor(GameController.instance.CursorController.DefaultCursorIndex);
                GameController.instance.EnableTime(false);
                break;
        }
    }

    void Pause()
    {
        GameController.instance.UserInterface.PauseMenu.SetActive(true);
    }

    void Win()
    {
        GameController.instance.UserInterface.WinScreen.SetActive(true);
        //GameController.instance.UserInterface.SetWinText();
    }

    void Loose()
    {
        GameController.instance.UserInterface.LoseScreen.SetActive(true);
    }

    void ShowTutorial()
    {
        GameController.instance.UserInterface.TutorialMenu.SetActive(true);
    }
}
