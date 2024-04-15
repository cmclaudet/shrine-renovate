using System.Linq;

public class InventoryViewController
{
    private readonly InventoryView view;

    public InventoryViewController(InventoryView view)
    {
        this.view = view;
    }

    public void Start()
    {
        UpdateView();
    }

    public void UpdateView()
    {
        var playerResources = GameManager.Instance.Inventory.GetResources();
        if (playerResources.Count == 0 || playerResources.Values.Sum() == 0)
        {
            Hide();
            return;
        }
        
        Display();
        
        var views = view.inventoryResourceViews;
        var viewIndex = 0;
        foreach (var resource in playerResources)
        {
            var resourceView = views[viewIndex];
            resourceView.gameObject.SetActive(true);

            var resourceSprite = GameManager.Instance.ResourceRegistry.GetResourceSprite(resource.Key);
            if (resourceSprite != null)
            {
                resourceView.resourceImage.sprite = resourceSprite;
                resourceView.resourceImage.gameObject.SetActive(true);
            }
            resourceView.amountText.gameObject.SetActive(true);
            resourceView.amountText.text = $"x{resource.Value}";
            viewIndex++;
        }
        
        for (int i = viewIndex; i < views.Length; i++) {
            views[i].gameObject.SetActive(false);
        }
    }

    void Display()
    {
        view.gameObject.SetActive(true);
    }

    void Hide()
    {
        view.gameObject.SetActive(false);
    }
}