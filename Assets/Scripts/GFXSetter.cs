using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GFXSetter : MonoBehaviour {

    private enum GfxType
    {
		FishSkin,
		LevelBack
    }

	[SerializeField] private GfxType gfxType;

	// Use this for initialization
	void Start () {
		if (GameData.instance)
		{
			if (gfxType == GfxType.FishSkin)
			{
				GetComponent<SpriteRenderer>().sprite = GameData.instance.currentSkin.sprite;
			}
			else if (gfxType == GfxType.LevelBack)
            {
				GetComponent<Image>().sprite = GameData.instance.currentLevel.sprite;
            }	
		}
	}
}
