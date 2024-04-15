using UnityEngine;

public class PlayerPhysics
{
    private readonly float moveSpeed;
    private readonly Rigidbody2D rigidbody2D;
    private readonly PlayerInput playerInput;
    private bool canMove;

    public PlayerPhysics(float moveSpeed, Rigidbody2D rigidbody2D, PlayerInput playerInput)
    {
        this.moveSpeed = moveSpeed;
        this.rigidbody2D = rigidbody2D;
        this.playerInput = playerInput;
    }
    
    public void FixedUpdate()
    {
        if (playerInput.MovementInput != Vector2.zero && canMove)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + playerInput.MovementInput * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}