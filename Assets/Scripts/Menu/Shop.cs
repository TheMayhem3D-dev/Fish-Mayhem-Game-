using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    [Header("Components")]
    private GameData gameData;
    private ShopUI shopUI;

    [Header("General")]
    [SerializeField] private SkinData[] skinsData;
    [SerializeField] private LevelData[] levelsData;

    public SkinData[] SkinsData { get { return skinsData; } }
    public LevelData[] LevelsData { get { return levelsData; } }
    

	void Awake()
    {
		if(GameData.instance)
        {
            gameData = GameData.instance;
            gameData.currentSkin = skinsData[GameData.instance.playerData.currentSkin];
            gameData.currentLevel = levelsData[GameData.instance.playerData.currentLevel];
            
            if(gameData.playerData.skins.Length == 0)
            {
                gameData.playerData.skins = new int[skinsData.Length];
                gameData.playerData.skins[0] = 1;
            }

            if (gameData.playerData.levels.Length == 0)
            {
                gameData.playerData.levels = new int[levelsData.Length];
                gameData.playerData.levels[0] = 1;
            }
        }

        shopUI = GetComponent<ShopUI>();
    }

    void Start()
    {
        SetUpShopUI();
    }

    void SetUpShopUI()
    {
        shopUI.SetUpCurrentCoins();

        shopUI.SetUpFishesNames(skinsData.Length);
        shopUI.SetUpFishesSprites(skinsData.Length);
        shopUI.SetUpFishesPrice(skinsData.Length);

        shopUI.SetUpLevelNames(levelsData.Length);
        shopUI.SetUpLevelsSprites(levelsData.Length);
        shopUI.SetUpLevelsPrice(levelsData.Length);
    }

    public void SaveShop()
    {
        for (int i = 0; i < skinsData.Length; i++)
        {
            if (skinsData[i] == GameData.instance.currentSkin)
            {
                GameData.instance.playerData.currentSkin = i;
            }
        }
        for (int i = 0; i < levelsData.Length; i++)
        {
            if (levelsData[i] == GameData.instance.currentLevel)
            {
                GameData.instance.playerData.currentLevel = i;
            }
        }

        gameData.SaveData();
    }

    public void ChangeSkin(int value)
    {
        if (gameData.playerData.skins[value] == 1)
        {
            gameData.currentSkin = skinsData[value];
        }
        SetUpShopUI();
        SaveShop();
    }

    public void ChangeLevel(int value)
    {
        if (gameData.playerData.levels[value] == 1)
        {
            gameData.currentLevel = levelsData[value];
        }
        SetUpShopUI();
        SaveShop();
    }

    public void BuySkin(int value)
    {
        if(gameData.playerData.coins >= skinsData[value].price)
        {
            gameData.playerData.coins -= skinsData[value].price;
            gameData.playerData.skins[value] = 1;
            SaveShop();
        }
        SetUpShopUI();
    }

    public void BuyLevel(int value)
    {
        if (gameData.playerData.coins >= levelsData[value].price)
        {
            gameData.playerData.coins -= levelsData[value].price;
            gameData.playerData.levels[value] = 1;
            SaveShop();
        }
        SetUpShopUI();
    }

    public void ShowSkinInfo(int value)
    {
        shopUI.EnableInfoCard(true);
        shopUI.SetUpInfoCard(value);
    }
}
