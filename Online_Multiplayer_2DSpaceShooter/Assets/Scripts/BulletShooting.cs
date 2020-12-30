using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;

public class BulletShooting : NetworkBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float Speed;

    void Update()
    {
        if(this.isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
           this.CmdShoot();
		}
    }
    [Command]
    void CmdShoot()
	{
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * Speed;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 1f);
	}
}
