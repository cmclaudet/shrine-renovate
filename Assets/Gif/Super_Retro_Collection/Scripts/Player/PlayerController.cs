using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController
{
    private readonly PlayerView view;
    private readonly PlayerInput input;
    private readonly PlayerPhysics physics;
    private readonly PlayerRenderer renderer;
    private bool canMove;

    public bool CanMove
    {
        get => canMove;
        set
        {
            canMove = value;
            physics.SetCanMove(canMove);
            renderer.SetCanMove(canMove);
        }
    }

    public PlayerController(PlayerView view)
    {
        this.view = view; 
        input = new PlayerInput(view.interactionBoxes);
        physics = new PlayerPhysics(view.moveSpeed, view.rb, input);
        renderer = new PlayerRenderer(view.animator, input, view.initialFacingDirection);
        CanMove = true;
    }

    public void OnMove(InputValue movementValue)
    {
        input.OnMove (movementValue);
    }

    public void OnInteract()
    {
        input.OnInteract();
    }

    public void Update()
    {
        renderer.Update();
    }

    public void FixedUpdate()
    {
        physics.FixedUpdate();
    }
    
    public IEnumerator CollectResource(string animationName)
    {
        if (!string.IsNullOrEmpty(animationName))
        {
            renderer.PlayAnimation(animationName);
            yield return PauseMoveUntil(0.5f); // todo use events to get animation end
        }
    }

    public void PlayAnimation(string animationName)
    {
        renderer.PlayAnimation(animationName);
    }

    IEnumerator PauseMoveUntil(float duration)
    {
        CanMove = false;
        yield return new WaitForSeconds(duration);
        CanMove = true;
    }
}