using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowDamage : MonoBehaviour
{
    EnemyYellowExplode explosion;
    public Ship enemyYellow, player;
    public GameObject bulletStorage;
    string collisionTag;

    private void Awake()
    {
        explosion = gameObject.GetComponent<EnemyYellowExplode>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Yellow collided with something!");
        collisionTag = other.gameObject.tag;

        if (collisionTag =="Player")
        {
            //make player take damage
           // Debug.Log("Yellow collided with player!");
            GetComponent<EnemyYellowMovement>().enabled = false;
            other.GetComponent<PlayerCollisions>().TakeDamage(enemyYellow.damage);
            explosion.Explode();
        }
        if (collisionTag == "bullet")
        {
           // Debug.Log("Yellow collided with the player bullet!");
            enemyYellow.health -= player.damage;
            other.transform.position = bulletStorage.transform.position;
            if (enemyYellow.health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
