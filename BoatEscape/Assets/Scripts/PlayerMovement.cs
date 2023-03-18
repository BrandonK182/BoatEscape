using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0.0f;
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpSpeed = 7.0f;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hello World!");
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
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
        }
        else if (dirX < 0.0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
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
}
