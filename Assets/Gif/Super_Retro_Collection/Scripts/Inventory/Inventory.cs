
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private readonly InventoryViewController inventoryViewController;
    readonly Dictionary<ResourceType, int> currentResources = new (); // todo init from state

    public Inventory(InventoryViewController inventoryViewController)
    {
        this.inventoryViewController = inventoryViewController;
    }

    public Dictionary<ResourceType, int> GetResources()
    {
        return currentResources;
    }
    
    public bool HasResources(params Resource[] resources)
    {
        foreach (var resource in resources)
        {
            if (currentResources.TryGetValue(resource.type, out int amount))
            {
                if (amount < resource.amount)
                {
                    return false; 
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
    
    public void AddResource (params Resource[] resources)
    {
        foreach (var resource in resources)
        {
            if (currentResources.TryGetValue(resource.type, out int amount))
            {
                currentResources[resource.type] += resource.amount;
            }
            else
            {
                currentResources[resource.type] = resource.amount;
            }
        }

        inventoryViewController.UpdateView();
    }

    public void RemoveResource(params Resource[] resources)
    {
        foreach (var resource in resources)
        {
            if (currentResources[resource.type] >= resource.amount)
            {
                currentResources[resource.type] -= resource.amount;
            }
            else
            {
                Debug.Log($"Not enough resources of type {resource.type} to remove amount {resource.amount}");
                currentResources[resource.type] = 0;
            }
        }
        
        inventoryViewController.UpdateView();
    }
}