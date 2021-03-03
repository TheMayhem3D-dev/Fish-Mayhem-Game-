using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LocalizedTextMeshPro : MonoBehaviour {

	[Header("General")]
	[SerializeField] private string key = string.Empty; // Ключ для значения
	[SerializeField] private LocalizationManager.LocalizedFiles localizedFileName = LocalizationManager.LocalizedFiles.Menu; // Файл из какого нужно брать значение
	private Text text;
	void Start ()
	{
		if (LocalizationManager.instance == true)
		{
			bool start = LocalizationManager.instance.GetIsReady();

			if (start == true)
			{
				SetText();
			}
		}
	}

	//Устанавливаем текст
	public void SetText()
	{
		TextMeshProUGUI text = GetComponent<TextMeshProUGUI> ();

		text.text = LocalizationManager.instance.GetLocalizedValue(key, localizedFileName);
	}
}
