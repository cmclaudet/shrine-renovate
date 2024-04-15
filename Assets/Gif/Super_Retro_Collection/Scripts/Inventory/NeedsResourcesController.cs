using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NeedsResourcesController
{
    private readonly NeedsResourcesView view;

    public NeedsResourcesController(NeedsResourcesView view)
    {
        this.view = view;
    }

    public void Start()
    {
        Hide();
    }

    public void Display(Resource[] neededResources)
    {
        view.gameObject.SetActive(true);
        UpdateView(neededResources);
    }

    public void Hide()
    {
        view.gameObject.SetActive(false);
    }

    private void UpdateView(Resource[] neededResources)
    {
        var playerResources = GameManager.Instance.Inventory.GetResources();
        var viewIndex = 0;
        var views = view.resourceViews;
        
        foreach (var resource in neededResources)
        {
            var resourceView = view.resourceViews[viewIndex];
            resourceView.gameObject.SetActive(true);

            var resourceSprite = GameManager.Instance.ResourceRegistry.GetResourceSprite(resource.type);
            if (resourceSprite != null)
            {
                resourceView.resourceImage.sprite = resourceSprite;
                resourceView.resourceImage.gameObject.SetActive(true);
            }
            resourceView.amountText.gameObject.SetActive(true);
            UpdateText(resourceView.amountText, resource.type, resource.amount, playerResources);
            viewIndex++;
        }
        
        for (int i = viewIndex; i < views.Length; i++) {
            views[i].gameObject.SetActive(false);
        }
    }

    private void UpdateText(TMP_Text textView, ResourceType type, int amountNeeded, Dictionary<ResourceType,int> playerResources)
    {
        playerResources.TryGetValue(type, out int playerAmount);
        textView.text = $"{playerAmount}/{amountNeeded}";
        textView.color = playerAmount >= amountNeeded ? Color.green : Color.red;
    }
}