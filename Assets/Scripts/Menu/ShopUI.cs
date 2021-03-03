using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour {

    [Header("Components")]
    private Shop shop;

    [Header("General")]
    [SerializeField] private TextMeshProUGUI currentCoinsLabel;
    [Space]
    [SerializeField] private ItemController[] fishControllers;
    [SerializeField] private ItemController[] levelControllers;

    [Header("Current")]
    [SerializeField] private Image currentFishImage;
    [SerializeField] private Image currentLevelImage;
    [Space]
    [SerializeField] private TextMeshProUGUI currentFishName;
    [SerializeField] private TextMeshProUGUI currentLevelName;

    [Header("InfoCard")]
    [SerializeField] private GameObject infoCard;
    [SerializeField] private Image infoFishImage;
    [SerializeField] private TextMeshProUGUI infoFishName;
    [SerializeField] private TextMeshProUGUI infoFishHealth;
    [SerializeField] private Slider infoFishSpeed;

    void Awake()
    {
        shop = GetComponent<Shop>();
    }

    void Start()
    {
        SetUpCurrentCoins();
    }

    public void SetUpCurrentCoins()
    {
        if (GameData.instance)
        {
            currentCoinsLabel.text = GameData.instance.playerData.coins.ToString();
        }
    }

    public void SetUpFishesNames(int length)
    {
        if (LocalizationManager.instance == true && GameData.instance == true)
        {
            currentFishName.text = LocalizationManager.instance.GetLocalizedValue(GameData.instance.currentSkin.localizedName, LocalizationManager.LocalizedFiles.Fishes);

            for (int i = 0; i < length; i++)
            {
                fishControllers[i].ItemName.text = LocalizationManager.instance.GetLocalizedValue(shop.SkinsData[i].localizedName, LocalizationManager.LocalizedFiles.Fishes);
            }
        }
    }

    public void SetUpFishesSprites(int length)
    {
        if(GameData.instance == true)
        {
            currentFishImage.sprite = GameData.instance.currentSkin.sprite;
        }

        for (int i = 0; i < length; i++)
        {
            fishControllers[i].ItemImage.sprite = shop.SkinsData[i].sprite;
        }
    }

    public void SetUpFishesPrice(int length)
    {
        for (int i = 0; i < length; i++)
        {
            fishControllers[i].PriceLabel.text = shop.SkinsData[i].price.ToString() + "$";

            if (GameData.instance)
            {
                if (GameData.instance.playerData.skins[i] == 0)
                {
                    fishControllers[i].ButtonSet.gameObject.SetActive(false);
                    fishControllers[i].ButtonBuy.gameObject.SetActive(true);

                    if (GameData.instance.playerData.coins >= shop.SkinsData[i].price)
                    {
                        fishControllers[i].ButtonBuy.interactable = true;
                    }
                    else
                    {
                        fishControllers[i].ButtonBuy.interactable = false;
                    }
                }
                else
                {
                    fishControllers[i].ButtonSet.gameObject.SetActive(true);
                    fishControllers[i].ButtonBuy.gameObject.SetActive(false);
                }

                if (GameData.instance.currentSkin == shop.SkinsData[i])
                {
                    fishControllers[i].ButtonSet.interactable = false;
                }
                else
                {
                    fishControllers[i].ButtonSet.interactable = true;
                }
            }
        }
    }

    public void SetUpLevelNames(int length)
    {
        if (LocalizationManager.instance == true && GameData.instance == true)
        {
            currentLevelName.text = LocalizationManager.instance.GetLocalizedValue(GameData.instance.currentLevel.localizedName, LocalizationManager.LocalizedFiles.Levels);

            for (int i = 0; i < length; i++)
            {
                levelControllers[i].ItemName.text = LocalizationManager.instance.GetLocalizedValue(shop.LevelsData[i].localizedName, LocalizationManager.LocalizedFiles.Levels);
            }
        }
    }

    public void SetUpLevelsSprites(int length)
    {
        if (GameData.instance == true)
        {
            currentLevelImage.sprite = GameData.instance.currentLevel.sprite;
        }

        for (int i = 0; i < length; i++)
        {
            levelControllers[i].ItemImage.sprite = shop.LevelsData[i].sprite;
        }
    }

    public void SetUpLevelsPrice(int length)
    {
        for (int i = 0; i < length; i++)
        {
            levelControllers[i].PriceLabel.text = shop.LevelsData[i].price.ToString() + "$";

            if (GameData.instance)
            {
                if (GameData.instance.playerData.levels[i] == 0)
                {
                    levelControllers[i].ButtonSet.gameObject.SetActive(false);
                    levelControllers[i].ButtonBuy.gameObject.SetActive(true);

                    if (GameData.instance.playerData.coins >= shop.LevelsData[i].price)
                    {
                        levelControllers[i].ButtonBuy.interactable = true;
                    }
                    else
                    {
                        levelControllers[i].ButtonBuy.interactable = false;
                    }
                }
                else
                {
                    levelControllers[i].ButtonSet.gameObject.SetActive(true);
                    levelControllers[i].ButtonBuy.gameObject.SetActive(false);
                }

                if (GameData.instance.currentLevel == shop.LevelsData[i])
                {
                    levelControllers[i].ButtonSet.interactable = false;
                }
                else
                {
                    levelControllers[i].ButtonSet.interactable = true;
                }
            }
        }
    }

    public void EnableInfoCard(bool value)
    {
        infoCard.SetActive(value);
    }

    public void SetUpInfoCard(int value)
    {
        infoFishImage.sprite = shop.SkinsData[value].sprite;
        infoFishName.text = LocalizationManager.instance.GetLocalizedValue(shop.SkinsData[value].localizedName, LocalizationManager.LocalizedFiles.Fishes);
        infoFishHealth.text = shop.SkinsData[value].health.ToString();
        infoFishSpeed.value = shop.SkinsData[value].speed;
    }
}
