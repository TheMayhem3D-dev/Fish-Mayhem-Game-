using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Загрузка меню
    public void LoadMenu(string value)
    {
        //GameController.instance.CursorController.ChangeCursor(GameController.instance.CursorController.DefaultCursorIndex);
        SceneManager.LoadScene(value);
    }

    public void ClosePauseMenu()
    {
        GameController.instance.GameState.ChangeGameState(GameState.Active);
    }
}
