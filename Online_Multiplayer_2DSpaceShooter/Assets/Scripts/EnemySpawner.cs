using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    
    [SerializeField]
    private float spawnTime = 1f;
    
    [SerializeField]
    private float speed = 1f;

    public override void OnStartServer()
    {
        InvokeRepeating("SpawnEnemy", this.spawnTime, this.spawnTime);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), transform.position.y);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity) as GameObject;
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        NetworkServer.Spawn(enemy);
        Destroy(enemy, 10f);
    }
}
