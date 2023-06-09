using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hello World!");
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(dirX * 7f, player.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector3(player.velocity.x,7,0);
        }
    }
}
