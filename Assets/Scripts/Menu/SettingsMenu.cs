using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

// Меню настроек
public class SettingsMenu : MonoBehaviour 
{
	#region Singleton

	public static SettingsMenu instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		//DontDestroyOnLoad(gameObject);
	}

	#endregion

	[Header("Sound&Music")]
	public AudioMixer musicAudioMixer;
	public AudioMixer soundAudioMixer;
	[Space]
	public Slider musicSlider;
	public Slider soundSlider;

	[Header("Localization (Languages)")]
	public TMP_Dropdown languagesDropdown;
	public string[] languages;

	[Header("Resolution")]
	private Resolution[] resolutions;
	public TMP_Dropdown resolutionDropdown;

	public int resolutionWidth;
	public int resolutionHeight;

	[Header("Fullscreen")]
	public Toggle fullscreenToggle;

	[Header("Quality")]
	public string[] quality; 
	public TMP_Dropdown qualityDropdown;

	void Start()
	{
		if (DataController.instance == true)
		{
			DataController.instance.LoadSettings();
		}

		SetUp();
	}

	// Установление параметров касающихся системы
	void SetUp()
	{
		print("Setting up settings parameters...");

		SetUpLocalizationDropdown();
		SetUpResolutionDropdown();
		SetUpQuality();

		print("Setting up complete succesfull!");
	}

	// Настройка возможных языков для игрока
	void SetUpLocalizationDropdown()
	{
		if (LocalizationManager.instance == true)
		{
			for (int i = 0; i < languages.Length; i++)
			{
				if (LocalizationManager.instance.defaultLang == languages[i])
				{
					languagesDropdown.value = i;
					languagesDropdown.RefreshShownValue();
				}
			}
		}
	}

	// Установка языка
	public void SetDefLang(int langIndex)
	{
		if (LocalizationManager.instance == true)
		{
			LocalizationManager.instance.SetLanguage(languages[langIndex]);

			print("SetDefLang has been started...");
			print("(Need to save) For current session Default Language is " + languages[langIndex]);
		}
	}


	// Настройка возможных разрешений экрана для конкретного монитора
	void SetUpResolutionDropdown()
	{
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == resolutionWidth && resolutions[i].height == resolutionHeight)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	// Установка игроком разрешения экрана через меню настроек
	public void SetResolutionFromDropdown (int resolutionIndex)
	{
		Resolution resolution = resolutions [resolutionIndex];
		SetResolution(resolution.width, resolution.height);
	}

	// Установка разрешения экрана
	public void SetResolution(int width, int height)
	{
		Screen.SetResolution(width, height, Screen.fullScreen);
		resolutionWidth = width;
		resolutionHeight = height;

		print("Resolution set to: " + width + "x" + height);
	}


	// Установления значения для слайдера "Громкость Звуков"
	public void SetSoundSlider(float volume)
	{
		soundSlider.value = volume;
	}

	// Громкость звуков
	public void SetSoundVolume(float volume)
	{
		soundAudioMixer.SetFloat("sound volume", volume);
	}


	// Установления значения для слайдера "Громкость Музыки"
	public void SetMusicSlider(float volume)
	{
		musicSlider.value = volume;
	}

	// Громкость музыки
	public void SetMusicVolume (float volume)
	{
		musicAudioMixer.SetFloat("music volume", volume);
	}

	// Настройка возможных графических уровней доступных игроку (for Localization Manager)
	public void SetUpQuality()
	{
		if (LocalizationManager.instance == true)
		{
		qualityDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentQualityIndex = 0;
			for (int i = 0; i < quality.Length; i++)
			{
				string option = LocalizationManager.instance.GetLocalizedValue(quality[i], 0);
				options.Add(option);

				if (i == QualitySettings.GetQualityLevel())
				{
					currentQualityIndex = i;
				}
			}

			qualityDropdown.AddOptions(options);
			qualityDropdown.value = currentQualityIndex;
			qualityDropdown.RefreshShownValue();
		}
	}

	// Установка графического качества (for Data Controller)
	public void SetQuality (int qualityIndex)
	{
		QualitySettings.SetQualityLevel (qualityIndex);
		print("Set quality level to " + qualityIndex.ToString());
	}

	// Установка полного экрана(оконного режима)
	public void SetUpFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
		fullscreenToggle.isOn = isFullscreen;
		print("Setting up fullscreen to " + isFullscreen.ToString());
	}

	// Переключение полного экрана(оконного режима)
	public void ToggleFullscreen ()
	{
		Screen.fullScreen = !Screen.fullScreen;
		print("Set fullscreen to " + Screen.fullScreen.ToString());
	}


	// Применение изменений
	public void ApplyChanges ()
	{
		print("Applying changes...");

		if (DataController.instance == true) 
		{
			DataController.instance.SaveSettings();
		}

		print("Changes applied succesfull!");
	}

	// Откат изменений
	public void RevertChanges()
	{
		print("Reverting changes...");

		if (DataController.instance == true)
		{
			DataController.instance.LoadSettings();
		}

		SetUp();

		print("Changes reverted succesfull!");
	}
}
