using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    [TextArea(3, 5)]
    public string itemDescription;
    public Sprite itemIcon;
}
