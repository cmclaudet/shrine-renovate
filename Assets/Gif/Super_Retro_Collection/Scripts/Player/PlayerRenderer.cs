using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer
{
    private readonly Animator animator;
    private readonly PlayerInput input;

    private Vector2 previousPosition;
    private string loadedSpriteSheetName;
    private Dictionary<string, Sprite> spriteSheet;
    private Vector2 movement;
    private bool canMove;

    public PlayerRenderer(Animator animator, PlayerInput input, Vector2 initialFacingDirection)
    {
        this.animator = animator;
        this.input = input;

        // animator.SetFloat("speed", 0);
        // animator.SetInteger("orientation", 4);
        animator.SetFloat("moveX", initialFacingDirection.x);
        animator.SetFloat("moveY", initialFacingDirection.y);
    }
    
    public void Update()
    {
        movement = input.MovementInput;

        AnimationUpdate();
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void PlayAnimation(string animationStateName)
    {
        Debug.Log($"Try play {animationStateName}");
        animator.Play($"Base Layer.{animationStateName}");
    }

    private void AnimationUpdate()
    {
        if (canMove == false)
        {
            animator.SetBool("isWalking", false);
            // animator.SetFloat("speed", 0);
        }
        else
        {
            var isMoving = Mathf.Abs(movement.x) + Mathf.Abs(movement.y) > 0.01f;
            animator.SetBool("isWalking", isMoving);
            if (isMoving)
            {
                animator.SetFloat("moveX", movement.x);
                animator.SetFloat("moveY", movement.y);
            }
            // animator.SetFloat("speed", Mathf.Abs(movement.x) + Mathf.Abs(movement.y));
            // if (movement.x > 0)
            //     animator.SetInteger("orientation", 6);
            // if (movement.x < 0)
            //     animator.SetInteger("orientation", 2);
            // if (movement.y > 0)
            //     animator.SetInteger("orientation", 0);
            // if (movement.y < 0)
            //     animator.SetInteger("orientation", 4);
        }
    }
}
