using System;
using System.Collections.Generic;
using UnityEngine;

// Все вещи которые нужно сохранить/загрузить находятся здесь
[Serializable]
public class PlayerData
{
	[Header("General")]
	public int coins;

	public int[] skins;
	public int[] levels;

	public int currentSkin;
	public int currentLevel;

	// Установление стандартных значений
	public void SetDefaultValues()
	{
		// Основные значенияs
		coins = 0;
		skins = new int[0];
		levels = new int[0];

		currentSkin = 0;
		currentLevel = 0;
	}
}
