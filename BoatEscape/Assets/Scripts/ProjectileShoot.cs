using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    private Rigidbody2D projectile;
    [SerializeField] private Rigidbody2D player;

    private float dirX = 0.0f;
    [SerializeField] private float xSpeed = 12f;
    [SerializeField] private float ySpeed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("creating projectile");
        projectile = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            projectile.transform.localPosition = new Vector2(player.transform.localPosition.x + 1f, player.transform.localPosition.y);
            projectile.velocity = new Vector2(xSpeed, ySpeed);
        }
    }
}
