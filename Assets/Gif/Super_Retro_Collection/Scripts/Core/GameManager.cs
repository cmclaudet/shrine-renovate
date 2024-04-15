using System.Collections;
using System.Linq;
using DialogueSystemWithText;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Inventory Inventory { get; private set; }
    public NeedsResourcesController NeedsResourcesController { get; private set; }
    public PlayerController PlayerController { get; private set; }
    public ResourceRegistry ResourceRegistry { get; private set; }
    
    public GameObject ButtonPrompt { get; private set; }

    private int totalBrokenObjects;
    private int brokenObjectsFixed;

    private static GameManager instance;
    private DialogueUIController endDialogueUIController;
    private AudioSource audioSource;
    private AudioClip[] audioClips;

    public static GameManager Instance {
        get {
            if (instance == null) {
                GameObject go = new GameObject ("GameManager");
                instance = go.AddComponent<GameManager> ();
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    public void Init(Inventory inventory, ResourceRegistry resourceRegistry,
        PlayerController playerController, NeedsResourcesController needsResourcesController, int totalBrokenObjects,
        DialogueUIController endDialogueUIController, GameObject buttonPrompt, AudioSource audioSource,
        AudioClip[] audioClips)
    {
        Inventory = inventory;
        PlayerController = playerController;
        ResourceRegistry = resourceRegistry;
        NeedsResourcesController = needsResourcesController;
        this.totalBrokenObjects = totalBrokenObjects;
        this.endDialogueUIController = endDialogueUIController;
        ButtonPrompt = buttonPrompt;
        this.audioSource = audioSource;
        this.audioClips = audioClips;
    }

    public void IncrementBrokenObjectsFixed()
    {
        brokenObjectsFixed++;
        if (brokenObjectsFixed >= totalBrokenObjects)
        {
            PlayerController.CanMove = false;
            StartCoroutine(StartEndDialogueDelayed());
        }
    }

    public void PlaySoundEffect(string clipName)
    {
        var clip = audioClips.FirstOrDefault(clip => clip.name == clipName);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    IEnumerator StartEndDialogueDelayed()
    {
        yield return new WaitForSeconds(1f);
        endDialogueUIController.ShowDialogueUI();
    }
}