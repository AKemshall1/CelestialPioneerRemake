using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueCollisions : MonoBehaviour
{
    public Ship enemyBlue, player;

    private GameObject bulletStorage;
    private EnemyBlueUtility uti;

    private void Start()
    {
        uti = gameObject.GetComponent<EnemyBlueUtility>();
        bulletStorage = GameObject.FindWithTag("BulletStorage");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {

            enemyBlue.health -= player.damage;
            collision.transform.position = bulletStorage.transform.position;
            uti.CheckforDeath();

        }

    }

}
