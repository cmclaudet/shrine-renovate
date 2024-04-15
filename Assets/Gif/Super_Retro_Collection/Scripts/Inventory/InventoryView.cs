using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public ResourceView[] inventoryResourceViews;
    private InventoryViewController controller;

    public void Init(InventoryViewController controller)
    {
        this.controller = controller;
    }

    private void Start()
    {
        controller.Start();
    }
}
