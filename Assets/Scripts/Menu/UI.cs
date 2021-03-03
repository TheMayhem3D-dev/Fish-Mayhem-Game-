using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour {
	[Header("General")]
	[SerializeField] private GameObject pauseMenu = null;
	[SerializeField] private GameObject winScreen = null;
	[SerializeField] private GameObject loseScreen = null;
	[SerializeField] private GameObject tutorialMenu = null;

	[Header("Player")]
	[SerializeField] private TextMeshProUGUI healthText;
	[SerializeField] private TextMeshProUGUI coinText;

	public GameObject PauseMenu { get { return pauseMenu; } }
	public GameObject WinScreen { get { return winScreen; } }
	public GameObject LoseScreen { get { return loseScreen; } }

	public GameObject TutorialMenu { get { return tutorialMenu; } }

	public void SetHealthUI(int value)
    {
		healthText.text = value.ToString();
    }

	public void SetCoinUI(int value)
    {
		coinText.text = value.ToString();
	}
}
