using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrokenObjectController
{
    private readonly BrokenObjectView view;
    private int upgradeLevelIndex;
    private bool isFullyUpgraded;

    public BrokenObjectController(BrokenObjectView view)
    {
        this.view = view;
    }

    public void Start()
    {
        UpdateUpgradeState();
    }

    void UpdateUpgradeState()
    {
        for (int i = 0; i < view.upgradeLevelData.Length; i++)
        {
            view.upgradeLevelData[i].upgradeState.SetActive(i == upgradeLevelIndex);
        }
    }
    
    public void OnInteract()
    {
        Debug.Log($"Try interact {view.gameObject.name}");
        Debug.Log($"upgrade lvl index {upgradeLevelIndex}");
        Debug.Log($"upgrade data len {view.upgradeLevelData.Length}");
        if (upgradeLevelIndex >= view.upgradeLevelData.Length - 1)
        {
            return;
        }
        
        var resourcesNeeded = view.upgradeLevelData[upgradeLevelIndex].resourcesNeeded;

        if (GameManager.Instance.Inventory.HasResources(resourcesNeeded))
        {
            GameManager.Instance.Inventory.RemoveResource(resourcesNeeded);
            Upgrade();
        }
        else
        {
            List<string> resourceDescriptions = resourcesNeeded.Select(r => $"{r.type}: x{r.amount}").ToList();
            Debug.Log($"You need {string.Join(", ", resourceDescriptions)}");
        }
    }

    public void OnInteractiveStart()
    {
        if (isFullyUpgraded == false)
        {
            GameManager.Instance.NeedsResourcesController.Display(view.upgradeLevelData[upgradeLevelIndex]
                .resourcesNeeded);
        }
    }

    public void OnInteractiveEnd()
    {
        if (isFullyUpgraded == false)
        {
            GameManager.Instance.NeedsResourcesController.Hide();
        }
    }

    void Upgrade()
    {
        upgradeLevelIndex = Mathf.Min(upgradeLevelIndex + 1, view.upgradeLevelData.Length - 1);
        UpdateUpgradeState();
        GameManager.Instance.PlaySoundEffect("woodDrop");
        GameManager.Instance.IncrementBrokenObjectsFixed();
        if (upgradeLevelIndex >= view.upgradeLevelData.Length - 1)
        {
            OnInteractiveEnd();
            isFullyUpgraded = true;
        }
        else
        {
            OnInteractiveStart();
        }
    }
}