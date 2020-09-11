using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowCollisions : MonoBehaviour
{
    public Ship playerShip, enemyYellow;
    private LayerMask player = 1 << 9;
    private GameObject bulletStorage;
    private EnemyYellowUtility uti;
    // Start is called before the first frame update
    void Start()
    {
        bulletStorage = GameObject.FindWithTag("BulletStorage");
        uti = gameObject.GetComponent<EnemyYellowUtility>();
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(this.transform.position, .4f, player) && !uti.dead) //if not dead and finds the player in overlap circle
        {
            uti.hitPlayer = true;   //bool to reuse method. when exploding, only do damage to the player if the ship collided with the player. otherwise, it hit the bottom of the screen and shouldn't damage player
            uti.Explode(uti.hitPlayer);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            enemyYellow.health -= playerShip.damage; //take damage
            collision.transform.position = bulletStorage.transform.position;    //the bullet has been used to hit the enemy, meaning it needs to be put back with the player bullet pool
            uti.CheckforDeath();
        }
    }
}
