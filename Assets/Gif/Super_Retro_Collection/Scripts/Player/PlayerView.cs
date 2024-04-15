using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    public Animator animator;
    public PlayerInteractionBoxesView interactionBoxes;
    public Vector2 initialFacingDirection;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    
    private PlayerController controller;

    public void Init(PlayerController controller)
    {
        this.controller = controller;
    }

    private void Update()
    {
        controller.Update();
    }

    private void FixedUpdate()
    {
        controller.FixedUpdate();
    }
    
    private void OnMove(InputValue movementValue)
    {
        controller.OnMove(movementValue);
    }

    private void OnInteract()
    {
        controller.OnInteract();
    }
}