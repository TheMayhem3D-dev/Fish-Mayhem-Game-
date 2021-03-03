using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    #region Singleton

    public static GameController instance;

    void Awake()
    {
        instance = this;

        SetUpComponents();
    }

    #endregion

    [Header("General")]
    private GameData gameData;

    [Header("Objects")]
    [SerializeField] private Player player;

    [Header("Spawners")]
    [SerializeField] private Transform[] enemySpawners;
    [SerializeField] private Transform[] coinSpawners;

    [Header("Components")]
    private UI userInterface;
    private GameStateController gameState;

    [Header("Level limit")]
    public float rightLimit = 5f;
    public float leftLimit = 5f;
    public float topLimit = 5f;
    public float bottomLimit = 5f;

    public Transform[] EnemySpawners { get { return enemySpawners; } }
    public Transform[] CoinSpawners { get { return coinSpawners; } }

    public UI UserInterface { get { return userInterface; } }
    public GameStateController GameState { get { return gameState; } }

    void SetUpComponents()
    {
        if (GameData.instance)
            gameData = GameData.instance;

        userInterface = GetComponent<UI>();
        gameState = GetComponent<GameStateController>();

        player.SetUpComponents();
    }

    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState.ChangeGameState(global::GameState.Pause);
        }
    }

    public void AddCoins(int value)
    {
        if (GameData.instance)
        {
            gameData.playerData.coins += value;
            userInterface.SetCoinUI(gameData.playerData.coins);
        }
    }

    public void GameOver()
    {
        EnablePlayer(false);
        EnableTime(false);
        gameState.ChangeGameState(global::GameState.Loose);
    }

    public void  EnablePlayer (bool value)
    {
        if (value)
        {
            player.enabled = true;
        }
        else
        {
            player.enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    public void EnableTime(bool value)
    {
        if (value)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
