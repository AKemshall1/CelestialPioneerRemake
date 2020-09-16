using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowDamage : MonoBehaviour
{
    EnemyYellowExplode explosion;
    public Ship enemyYellow;

    private void Start()
    {
        explosion = GetComponent<EnemyYellowExplode>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //make player take damage
            Debug.Log("Collided with player");
            GetComponent<EnemyYellowMovement>().enabled = false;
            other.GetComponent<PlayerCollisions>().TakeDamage(enemyYellow.damage);
            explosion.Explode();
        }
    }
}
