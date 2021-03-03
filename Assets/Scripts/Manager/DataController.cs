using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class DataController : MonoBehaviour {

	#region Singleton

	public static DataController instance;

	void Awake()
	{
		instance = this;

		if (instance == null) 
		{
			instance = this;
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	#endregion

	private PlayerData data;

	// Очистка файла сохранения
	public void Reset()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			string path = Application.persistentDataPath + "/playerInfo.dat";
			File.Delete(path);

			print ("File exist, reset...");
			CreateSaveFile();
		} 
		else 
		{
			print ("File not exist, create new one...");
			CreateSaveFile();
		}
	}

	public void ResetSettings()
	{
		if (File.Exists(Application.persistentDataPath + "/settingsInfo.dat"))
		{
			string path = Application.persistentDataPath + "/settingsInfo.dat";
			File.Delete(path);

			print("Settings file exist, reset...");
			CreateSettingsSaveFile();
		}
		else
		{
			print("Settings file not exist, create new one...");
			CreateSettingsSaveFile();
		}
	}

	private void CreateSaveFile()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.SetDefaultValues();

		bf.Serialize(file, data);
		file.Close();
	}

	private void CreateSettingsSaveFile()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/settingsInfo.dat");

		SettingsData data = new SettingsData();
		data.SetDefaultValues();

		bf.Serialize(file, data);
		file.Close();
	}

	// Сохранение в файл
	public void Save()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat"))
		{
			print("Save in progress...");

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = new PlayerData ();

			if(GameData.instance)
            {
				data.coins = GameData.instance.playerData.coins;

				data.currentSkin = GameData.instance.playerData.currentSkin;
				data.currentLevel = GameData.instance.playerData.currentLevel;

				data.skins = new int[GameData.instance.playerData.skins.Length];
                for (int i = 0; i < data.skins.Length; i++)
                {
					data.skins[i] = GameData.instance.playerData.skins[i];
                }

				data.levels = new int[GameData.instance.playerData.levels.Length];
				for (int i = 0; i < data.levels.Length; i++)
				{
					data.levels[i] = GameData.instance.playerData.levels[i];
				}
			}

			bf.Serialize (file, data);
			file.Close ();

			print("Save complete!");
		}
		else
		{
			Reset ();
		}
	}

	// Загрузка файла сохранения
	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {

			print("Load in progress...");

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize (file);

			if(GameData.instance)
            {
				GameData.instance.playerData.coins = data.coins;

				GameData.instance.playerData.currentSkin = data.currentSkin;
				GameData.instance.playerData.currentLevel = data.currentLevel;

				GameData.instance.playerData.skins = new int[data.skins.Length];
				for (int i = 0; i < data.skins.Length; i++)
                {
					GameData.instance.playerData.skins[i] = data.skins[i];
				}

				GameData.instance.playerData.levels = new int[data.levels.Length];
				for (int i = 0; i < data.levels.Length; i++)
				{
					 GameData.instance.playerData.levels[i] = data.levels[i];
				}
			}

			file.Close();

			print("Load succesfull!");
		}
		else
		{
			Reset ();
		}
	}

	// Сохранение настроек
	public void SaveSettings()
	{
		if (File.Exists(Application.persistentDataPath + "/settingsInfo.dat"))
		{
			print("Save settings in progress...");

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/settingsInfo.dat", FileMode.Open);

			SettingsData data = new SettingsData();

			//Сохранение значения выбранного языка
			if (LocalizationManager.instance == true)
			{
				data.lang = LocalizationManager.instance.defaultLang;
			}

			//Сохранение значений из меню настроек
			if (SettingsMenu.instance == true)
			{
				//Громкость музыки и звуков
				data.volumeMusic = SettingsMenu.instance.musicSlider.value;
				data.volumeSound = SettingsMenu.instance.soundSlider.value;

				//Разрешение экрана
				data.resolutionWidth = SettingsMenu.instance.resolutionWidth;
				data.resolutionHeight = SettingsMenu.instance.resolutionHeight;
				print("Saving res: " + data.resolutionWidth + "x" + data.resolutionHeight);

				//Полный экран
				data.fullscreen = Screen.fullScreen;

				//Качество
				data.quality = QualitySettings.GetQualityLevel();
			}

			bf.Serialize(file, data);
			file.Close();

			print("Save complete!");
		}
		else
		{
			ResetSettings();
		}
	}

	// Загрузка настроек
	public void LoadSettings()
	{
		if (File.Exists(Application.persistentDataPath + "/settingsInfo.dat"))
		{
			print("Load settings in progress...");

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/settingsInfo.dat", FileMode.Open);

			SettingsData data = (SettingsData)bf.Deserialize(file);

			// Загрузка значения выбранного языка
			if (LocalizationManager.instance == true)
			{
				LocalizationManager.instance.defaultLang = data.lang;
			}

			// Загрузка значений для меню настроек
			if (SettingsMenu.instance == true)
			{
				// Музыка
				SettingsMenu.instance.SetMusicSlider(data.volumeMusic);
				SettingsMenu.instance.SetMusicVolume(data.volumeMusic);

				// Звуки
				SettingsMenu.instance.SetSoundSlider(data.volumeSound);
				SettingsMenu.instance.SetSoundVolume(data.volumeSound);

				// Разрешение экрана
				SettingsMenu.instance.resolutionWidth = data.resolutionWidth;
				SettingsMenu.instance.resolutionHeight = data.resolutionHeight;
				print("Loading res: " + data.resolutionWidth.ToString() + "x" + data.resolutionHeight.ToString());

				// Полный экран
				SettingsMenu.instance.SetUpFullscreen(data.fullscreen);

				// Качество
				SettingsMenu.instance.SetQuality(data.quality);
			}

			file.Close();

			print("Save complete!");
		}
		else
		{
			ResetSettings();
		}
	}
}
