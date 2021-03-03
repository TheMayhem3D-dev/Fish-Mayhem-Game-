using UnityEditorInternal;
using UnityEngine;

public class ItemData : ScriptableObject
{
    [Header("General")]
    public string localizedName;
    public Sprite sprite;

    [Tooltip("No negative values, please")]
    public int price;
}
