using System;
using UnityEngine;

public class PlayerInteractionBoxView : MonoBehaviour
{
    public IInteractive CurrentInteractive { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy == false)
        {
            return;
        }
        var interactive = other.GetComponent<IInteractive>();
        if (interactive != null)
        {
            Debug.Log($"Trigger enter {gameObject.name}, object {interactive.GameObject.name}");
            CurrentInteractive = interactive;
            CurrentInteractive.OnInteractiveStart();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy == false)
        {
            return;
        }
        var interactive = other.GetComponent<IInteractive>();
        if (interactive != null && CurrentInteractive == interactive)
        {
            Debug.Log($"Trigger exit {gameObject.name}, object {interactive.GameObject.name}");
            CurrentInteractive.OnInteractiveEnd();
            CurrentInteractive = null;
        }
    }

    private void OnDisable()
    {
        if (CurrentInteractive != null)
        {
            CurrentInteractive.OnInteractiveEnd();
            CurrentInteractive = null;
        }
    }
}
