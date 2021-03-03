using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

	[Header("UI")]
	[SerializeField] private TextMeshProUGUI itemName;
	[SerializeField] private Image itemImage;
	[SerializeField] private TextMeshProUGUI priceLabel;
	[SerializeField] private Button buttonBuy;
	[SerializeField] private Button buttonSet;

	public TextMeshProUGUI ItemName { get { return itemName; } }
	public Image ItemImage { get { return itemImage; } }
	public TextMeshProUGUI PriceLabel { get { return priceLabel; } }
	public Button ButtonBuy {  get { return buttonBuy; } }
	public Button ButtonSet { get { return buttonSet; } }
}
