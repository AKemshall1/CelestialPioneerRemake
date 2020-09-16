using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public Ship player, enemyBlue, enemyRed;
    public UIManager uiManager;
    
    PowerUpStats pus;
    
    string collisionTag;
    int damage;
    float fireRate, speed;

    private void Start()
    {
        pus = gameObject.GetComponent<PowerUpStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionTag = collision.gameObject.tag;

        switch (collisionTag)
        {
            case "EnemyRedBullet":
                player.health -= enemyRed.health;
                CheckDeath();
                if (player.health <= 0)
                {
                    player.lives--;
                    player.health = 100;
                }
                uiManager.UpdateHealthLives();
                break;
            case "EnemyBlueBullet":
                player.health -= enemyBlue.health;
                CheckDeath();
                if (player.health <= 0)
                {
                    player.lives--;
                    player.health = 100;
                }
                uiManager.UpdateHealthLives();
                break;
            case "DamageUp":
                Destroy(collision.gameObject);
                if (!pus.hasDamageUp)
                    pus.PowerUpDamage();
                break;
            case "FireRateUp":
                Destroy(collision.gameObject);
                if(!pus.hasFireUp)
                    pus.PowerUpFireRate();
                break;
            case "SpeedUp":
                Destroy(collision.gameObject);
                if (!pus.hasSpeedUp)
                    pus.PowerUpSpeed();
                break;
            case "HealthUp":
                player.health += 20;
                if (player.health > 100)
                    player.health = 100;
                uiManager.UpdateHealthLives();
                Destroy(collision.gameObject);
                break;
            case "LivesUp":
                player.lives++;
                if (player.lives > 3)
                    player.lives = 3;
                uiManager.UpdateHealthLives();
                Destroy(collision.gameObject);
                break;
        }
    }

    public void CheckDeath()
    {
        if (player.health <= 0)
        {
            if (player.lives <= 0)
            {
                Destroy(gameObject);
            }
            player.lives--;
            player.health = 100;
        }
    }

    public void TakeDamage(int enemyDamage)
    {
        player.health -= enemyDamage;
        if (uiManager != null)
        {
            Debug.Log("ui manager worlks bitch");
        }
        uiManager.UpdateHealthLives();
        CheckDeath();
    }
}
