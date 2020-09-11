using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedUtility : MonoBehaviour
{
    public Ship enemyRed;
    public GameObject damageUp, fireRateUp, speedUp, healthUp, livesUp;

    private EnemyRedShoot shoot;

    int randSpawn;
    private void Awake()
    {
        enemyRed.health = 10;
        shoot = this.gameObject.GetComponent<EnemyRedShoot>();
        
    }

    public void CheckforDeath()
    {
        if (enemyRed.health <= 0)
        {
            DestroyBullets();
            SpawnPowerUp();
            Destroy(this.gameObject);
        }
    }
    private void SpawnPowerUp()
    {
        randSpawn = Random.Range(1, 7);

        if (randSpawn == 1)
        {
            //generate a random number and choose a power up to spawn based on that
            int rand = Random.Range(1, 6);

            switch (rand)
            {
                case 1:
                    GameObject temp = Instantiate(damageUp);
                    temp.transform.position = gameObject.transform.position;
                    break;
                case 2:
                    GameObject temp2 = Instantiate(fireRateUp);
                    temp2.transform.position = gameObject.transform.position;
                    break;
                case 3:
                    GameObject temp3 = Instantiate(speedUp);
                    temp3.transform.position = gameObject.transform.position;
                    break;
                case 4:
                    GameObject temp4 = Instantiate(healthUp);
                    temp4.transform.position = gameObject.transform.position;
                    break;
                case 5:
                    GameObject temp5 = Instantiate(livesUp);
                    temp5.transform.position = gameObject.transform.position;
                    break;
            }
        }

    }


    public void DestroyBullets()
    {
        for (int i = 0; i < 3; i++)
        {

            Destroy(shoot.bulletArr[i].gameObject);
        }

    }

    public int GetEnemyRedDamage()
    {
        return enemyRed.damage;
    }
}
