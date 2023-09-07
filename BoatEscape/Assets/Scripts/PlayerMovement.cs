using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D projectile;
    private bool faceRight = false;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0.0f;
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpSpeed = 7.0f;

    [SerializeField] private float xSpeed = 12f;
    [SerializeField] private float ySpeed = 1f;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hello World!");
        player = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded() )
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if(faceRight)
            {
                projectile.transform.localPosition = new Vector2(player.transform.localPosition.x + 1f, player.transform.localPosition.y);
                projectile.velocity = new Vector2(xSpeed, ySpeed);
            }
            else
            {
                projectile.transform.localPosition = new Vector2(player.transform.localPosition.x - 1f, player.transform.localPosition.y);
                projectile.velocity = new Vector2(-xSpeed, ySpeed);
            }

        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state = MovementState.idle;
        if (dirX > 0.0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            faceRight = true;
        }
        else if (dirX < 0.0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            faceRight = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if (player.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (player.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int) state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
