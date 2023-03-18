using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0.0f;

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
        player.velocity = new Vector2(dirX * 7f, player.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector3(player.velocity.x,7,0);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (dirX > 0.0f)
        {
            anim.SetBool("is_running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0.0f)
        {
            anim.SetBool("is_running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("is_running", false);
        }
    }
}
