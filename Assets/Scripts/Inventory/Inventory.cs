using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Item currentItem = null;  // ������ ������ ���� �������

    public Item CurrentItem { get => currentItem; set => currentItem = value; }

    public void AddItem(GameObject item, Item newItem)
    {
        if (!item.GetComponent<MeshRenderer>().enabled)
            return;

        if (currentItem == null)
        {
            currentItem = newItem;
            ToggleItem(item, false);  // ��������� ������
            Debug.Log("Item added: " + newItem.itemName);
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (currentItem != null)
        {
            ToggleItem(item, true);  // �������� ������
            //MoveItem(currentItem, dropPosition);  // ���������� ������
            Debug.Log("Item removed: " + currentItem.itemName);
            currentItem = null;  // ������� ���������
        }
        else
        {
            Debug.Log("Inventory is empty!");
        }
    }

    public bool HasItem(Item itemToCheck)
    {
        return currentItem == itemToCheck;
    }

    public void ListInventory()
    {
        if (currentItem != null)
        {
            Debug.Log("Inventory item: " + currentItem.itemName);
        }
        else
        {
            Debug.Log("Inventory is empty!");
        }
    }

    private void ToggleItem(GameObject item, bool isActive)
    {
        item.gameObject.GetComponent<MeshRenderer>().enabled = isActive;
    }

    private void MoveItem(GameObject item, Vector3 newPosition)
    {
        item.transform.position = newPosition;
    }
}

