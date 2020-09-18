using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedCollisions : MonoBehaviour
{
    public Ship enemyRed, player;

    EnemyRedUtility uti;
    GameObject bulletStorage;

    private void Awake()
    {
        uti = gameObject.GetComponent<EnemyRedUtility>();
        bulletStorage = GameObject.FindWithTag("BulletStorage");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Player bullet collided with enemy red");
            enemyRed.health -= player.damage;
            collision.transform.position = bulletStorage.transform.position;
            uti.CheckforDeath();

        }

    }
}
