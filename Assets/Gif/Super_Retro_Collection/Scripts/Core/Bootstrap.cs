
using System;
using System.Collections;
using DialogueSystemWithText;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public PlayerView playerView;
    public GameObject buttonPrompt;
    public InventoryView inventoryView;
    public NeedsResourcesView needsResourcesView;
    public DialogueUIController dialogueUIController;
    public DialogueUIController endDialogueUIController;
    public BrokenObjectView[] brokenObjectViews;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = new PlayerController(playerView);
        playerView.Init(playerController);

        var inventoryViewController = new InventoryViewController(inventoryView);
        inventoryView.Init(inventoryViewController);
        var inventory = new Inventory(inventoryViewController);
        
        var needsResourcesController = new NeedsResourcesController(needsResourcesView);
        needsResourcesView.Init(needsResourcesController);
        
        var registry = new ResourceRegistry();

        var totalBrokenObjects = brokenObjectViews.Length;
        GameManager.Instance.Init(inventory, registry, playerController, needsResourcesController, totalBrokenObjects,
            endDialogueUIController, buttonPrompt, audioSource, audioClips);
    }

    private void Start()
    {
        StartCoroutine(StartDialogueDelayed());
        DisablePlayerMove();
    }

    public void DisablePlayerMove()
    {
        playerController.CanMove = false;
    }

    public void EnablePlayerMove()
    {
        playerController.CanMove = true;
    }

    IEnumerator StartDialogueDelayed()
    {
        yield return new WaitForSecondsRealtime(1f);
        dialogueUIController.ShowDialogueUI();
    }
}