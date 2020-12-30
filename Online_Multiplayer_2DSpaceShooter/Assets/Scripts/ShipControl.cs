using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShipControl : NetworkBehaviour
{
    [SerializeField]
    private float moveSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		if (this.isLocalPlayer)
		{
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * moveSpeed, 0);
		}
    }
}
