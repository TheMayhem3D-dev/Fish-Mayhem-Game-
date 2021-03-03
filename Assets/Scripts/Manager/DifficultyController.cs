using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

	[Header("General")]
	private int currentDifficultyLevel = 1;
	[SerializeField] private int maxDifficultyLevel = 4;

	[SerializeField] private Spawner enemySpawner;
	[SerializeField] private Spawner coinSpawner;

	[Header("Stats")]
	[SerializeField] private int enemyCountRate = 5;
	[SerializeField] private int coinCountRate = 2;

	[SerializeField] private float timeDifficultyGrow = 60;

	void Awake () {
		if(GameData.instance)
        {
			currentDifficultyLevel = GameData.instance.currentLevel.difficultyLevel;
        }
	}

	void Start()
    {
		enemySpawner.SpawnCount = currentDifficultyLevel * enemyCountRate;
		coinSpawner.SpawnCount = currentDifficultyLevel * coinCountRate;
    }

	IEnumerator DifficultyGrow()
    {
		yield return new WaitForSeconds(timeDifficultyGrow);

		if (currentDifficultyLevel < maxDifficultyLevel)
			currentDifficultyLevel++;
    }
}
