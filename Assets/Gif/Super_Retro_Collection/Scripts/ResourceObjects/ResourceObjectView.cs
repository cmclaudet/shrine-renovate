
using System.Collections;
using UnityEngine;

public class ResourceObjectView : MonoBehaviour, IInteractive
{
    public GameObject GameObject => gameObject;
    public Resource[] resources;
    public string playerCollectionAnimationName;
    public string collectionAudioClipName;
    public void OnInteract()
    {
        GameManager.Instance.Inventory.AddResource(resources);
        StartCoroutine(CollectResource());
    }

    public void OnInteractiveStart()
    {
        GameManager.Instance.ButtonPrompt.SetActive(true);
    }

    public void OnInteractiveEnd()
    {
        GameManager.Instance.ButtonPrompt.SetActive(false);
    }

    IEnumerator CollectResource()
    {
        yield return GameManager.Instance.PlayerController.CollectResource(playerCollectionAnimationName);
        if (collectionAudioClipName != "")
        {
            GameManager.Instance.PlaySoundEffect(collectionAudioClipName);
        }
        Destroy(gameObject);
    }
}