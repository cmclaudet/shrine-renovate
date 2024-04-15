using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerInteractionBoxesView : MonoBehaviour
{
    public PlayerInteractionBoxView[] interactionBoxes;

    [CanBeNull]
    public IInteractive TryGetCurrentInteractive()
    {
        var currentInteractionBox = interactionBoxes.FirstOrDefault(box => box.gameObject.activeInHierarchy);
        if (currentInteractionBox != null)
        {
            return currentInteractionBox.CurrentInteractive;
        }

        return null;
    }
}
