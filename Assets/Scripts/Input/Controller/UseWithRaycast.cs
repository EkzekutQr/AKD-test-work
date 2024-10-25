using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWithRaycast : MonoBehaviour, IUsingControllable
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask dropLayerMask;
    [SerializeField] private float raycastRange;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private Inventory inventory;

    private bool isRaycastTrowing;

    private void Start()
    {
        playerCamera = transform.GetComponentInChildren<CameraLauncher>().Cam.GetComponent<Camera>();
    }
    public void Use()
    {
        isRaycastTrowing = true;
    }
    private void Update()
    {
        if (!isRaycastTrowing) return;

        TrowRaycast();

        isRaycastTrowing = false;
    }
    private void TrowRaycast()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        RaycastHit hit;

        if (inventory.CurrentItem == null)
            Physics.Raycast(ray, out hit, raycastRange, layerMask, QueryTriggerInteraction.Collide);
        else
            Physics.Raycast(ray, out hit, raycastRange, dropLayerMask, QueryTriggerInteraction.Collide);


        if (hit.collider != null)
            Debug.Log(hit.collider.gameObject.name);

        if (hit.collider != null)
            if (inventory.CurrentItem == null)
                TakeItem(hit.transform.gameObject);
            else
                DropItem(hit.transform.gameObject);
    }
    private void TakeItem(GameObject item)
    {
        Item newItem = new Item(item.name);
        inventory.AddItem(item, newItem);
    }
    private void DropItem(GameObject item)
    {
        if (item.name == inventory.CurrentItem.itemName)
            inventory.RemoveItem(item);
        else
        {
            if (!AlterDrop(item))
                Debug.Log("WrongSpot");
        }
    }
    private bool AlterDrop(GameObject item)
    {
        Transform itemRoot = item.transform;

        bool isItemFinded = false;

        foreach (Transform itm in itemRoot)
        {
            Debug.Log(itm.name);
            if (itm.gameObject.name == inventory.CurrentItem.itemName)
            {
                inventory.RemoveItem(itm.gameObject); isItemFinded = true; break;
            }
        }
        return isItemFinded;
    }
}
