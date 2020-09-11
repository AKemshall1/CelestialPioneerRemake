using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowUtility : MonoBehaviour
{
    public Ship enemyYellow, player;
    public PlayerUtilities pm;
    public PlayerCollisions pc;
    public UIManager ui;
    public GameObject explosion, damageUp, fireRateUp, speedUp, healthUp, livesUp;

    public bool dead = false;
    public bool hitPlayer = false;

    private void SpawnPowerUp()
    {
        int randSpawn = Random.Range(1, 7);

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
    private IEnumerator waitSeconds(float seconds)
    {
        Debug.Log("Waitforseconds called");
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
    public int GetEnemyYellowDamage()
    {
        return enemyYellow.damage;
    }
    public void CheckforDeath() //check if dead
    {
        if (enemyYellow.health <= 0)
        {
            SpawnPowerUp();
            Destroy(this.gameObject);
        }
    }

    public void Explode(bool hitPlayer)
    {
        dead = true;
        Instantiate(explosion, this.gameObject.transform);  //instantiate the explosion at this position
        gameObject.GetComponent<SpriteRenderer>().enabled = false;  //disable elements of the main ship
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (hitPlayer)  //if the player was detected in range then damage them
        {
            player.health -= enemyYellow.damage;
            ui.UpdateHealthLives();
            pc.CheckDeath();
        }
        StartCoroutine("waitSeconds", 0.5f); //wait for the animation to play out then destroy
    }
}
