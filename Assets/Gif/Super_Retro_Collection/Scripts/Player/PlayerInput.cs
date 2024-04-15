using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput
{
    private readonly PlayerInteractionBoxesView interactionBoxes;
    public Vector2 MovementInput { get; private set; }

    public PlayerInput(PlayerInteractionBoxesView interactionBoxes)
    {
        this.interactionBoxes = interactionBoxes;
    }
    
    public void OnMove(InputValue movementValue) 
    {
        MovementInput = movementValue.Get<Vector2>();
    }

    public void OnInteract()
    {
        var currentInteractive = interactionBoxes.TryGetCurrentInteractive();
        if (currentInteractive != null)
        {
            currentInteractive.OnInteract();
        }
    }
}
