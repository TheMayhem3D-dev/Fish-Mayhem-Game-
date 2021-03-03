using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour {

	public enum LocalizedFiles
	{
		Menu,
		Game,
		Fishes,
		Levels
	}

	public  static LocalizationManager instance;

	public string defaultLang = "Rus/"; // Язык по-умолчанию

	[SerializeField] private string[] localizedTextsFileName = new string[0];
	[SerializeField] private Dictionary<string, string>[] localizedTexts;

	private bool isReady = false;
	private string missingTextString = "Localized text not found";

	void Awake () 
	{
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

	void Start()
	{
		MakeNewDictionary();

		DataController.instance.LoadSettings();
		LoadLocalizedText(defaultLang);
	}

	// Создание нового словаря
	void MakeNewDictionary()
	{
		localizedTexts = new Dictionary<string, string>[localizedTextsFileName.Length];
	}

	// Загрузка файлов локализации
	public void LoadLocalizedText(string fileName)
	{
		for (int j = 0; j < localizedTexts.Length; j++)
		{
			localizedTexts[j] = new Dictionary<string, string>();

			string filePath = Path.Combine(Application.streamingAssetsPath, fileName + localizedTextsFileName[j] + ".json");

			if (File.Exists(filePath))
			{
				string dataAsJson = File.ReadAllText(filePath);
				LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

				for (int i = 0; i < loadedData.items.Length; i++)
				{
					localizedTexts[j].Add(loadedData.items[i].key, loadedData.items[i].value);
				}

				Debug.Log(j + " Data loaded, dictionary contains: " + localizedTexts[j].Count + " entries");
			}
			else
			{
				Debug.LogError("Cannot find file!");
			}
		}
			
		isReady = true;
	}

	public string GetLocalizedValue(string key, LocalizedFiles locFile)
	{
		int i = (int)locFile;

		string result = missingTextString;
		if (localizedTexts[i].ContainsKey (key)) 
		{
			result = localizedTexts[i] [key];
		}

		return result;
	}

	public int GetLocalizedLength(LocalizedFiles locFile)
	{
		int i = (int)locFile;

		int result = 0;

		if(localizedTexts[i].Count > 0)
		{
			result = localizedTexts[i].Count;
		}

		return result;
	}
	
	public bool GetIsReady()
	{
		return isReady;
	}

	// Установка языка
	public void SetLanguage(string lang)
	{
		defaultLang = lang;
	}
}
