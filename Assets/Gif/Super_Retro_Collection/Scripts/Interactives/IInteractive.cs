
using UnityEngine;

public interface IInteractive
{
    void OnInteract();
    void OnInteractiveStart();
    void OnInteractiveEnd();
    GameObject GameObject { get; }
}