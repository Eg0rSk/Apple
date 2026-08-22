using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public ItemData itemData;

    private void OnMouseDown()
    {
        if (itemData != null)
        {
            Debug.Log("Назва: " + itemData.itemName);
            Debug.Log("Опис: " + itemData.itemDescription);
            
            if (itemData.itemIcon != null)
            {
                Debug.Log("Іконка: " + itemData.itemIcon.name);
            }
        }
        else
        {
            Debug.LogWarning("Для предмета не призначено ItemData!");
        }
    }
}