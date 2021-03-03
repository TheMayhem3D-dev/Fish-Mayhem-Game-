using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void NewGame()
	{
		if (DataController.instance == true) 
		{
			DataController.instance.Reset ();
		}
	}
	public void Continue()
	{
		if (DataController.instance == false) 
		{
			DataController.instance.Load ();
		}
	}

	//начинаем игру
	public void PlayGame(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	//выходим из игры
	public void QuitGame()
	{
		Debug.Log ("QUIT!");
		Application.Quit ();
	}

	public void ResetData()
	{
		DataController.instance.Reset();
	}

}
