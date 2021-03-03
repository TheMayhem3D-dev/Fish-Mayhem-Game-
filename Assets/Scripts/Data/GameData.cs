using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameData : MonoBehaviour {

	#region Singleton

	public static GameData instance;

	void Awake()
	{
		instance = this;

		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	#endregion

	[Header("General")]
	public PlayerData playerData;

	public SkinData currentSkin;
	public LevelData currentLevel;

	void Start()
    {
		if(DataController.instance)
        {
			DataController.instance.Load();
        }
    }

	public void SaveData()
    {
		if(DataController.instance)
        {
			DataController.instance.Save();
        }
    }
}
