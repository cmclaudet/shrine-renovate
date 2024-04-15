using System;
using UnityEngine;

public class BrokenObjectView : MonoBehaviour, IInteractive
{
    public GameObject GameObject => gameObject;

    public UpgradeLevelData[] upgradeLevelData;

    private BrokenObjectController controller;

    private void Awake()
    {
        controller = new BrokenObjectController(this);
    }

    private void Start()
    {
        controller.Start();
    }

    public void OnInteract()
    {
        controller.OnInteract();
    }

    public void OnInteractiveStart()
    {
        controller.OnInteractiveStart();
    }
    
    public void OnInteractiveEnd()
    {
        controller.OnInteractiveEnd();
    }
}

[Serializable]
public class UpgradeLevelData
{
    public Resource[] resourcesNeeded;
    public GameObject upgradeState;
}