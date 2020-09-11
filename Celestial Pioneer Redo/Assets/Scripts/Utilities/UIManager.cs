using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text healthText, scoreText, livesText;
    public Text damageText, fireRateText, speedText;
    public GameObject death;
    public Ship ship;

    int countSpeed = 0;
    int countDamage = 0;
    int countFireRate =0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthLives();
        UpdateScore(ship.score);
    }
    public void UpdateHealthLives()
    {
        Debug.Log("Updating health and lives");
        healthText.text = "Health: " + ship.health.ToString();
        livesText.text = "Lives: " + ship.lives.ToString();
    } 
    public void UpdateScore(int Number)
    {
        scoreText.text = "Score: " + Number.ToString();
    }

    public void UpdateSpeedText()
    {
        Debug.Log("Update Speed");
        if (countSpeed == 0)
        {
            speedText.color = Color.white;
            countSpeed++;
        }
        else
        {
            speedText.color = Color.black;
            countSpeed--;
        }
    }
    public void UpdateDamageText()
    {
        Debug.Log("Update Damage");
        if (countDamage == 0)
        {
            damageText.color = Color.white;
            countSpeed++;
        }
        else
        {
            damageText.color = Color.black;
            countDamage--;
        }
    }
    public void UpdateFireRateText()
    {
        Debug.Log("Update FireRate");
        if (countFireRate == 0)
        {
            fireRateText.color = Color.white;
            countFireRate++;
        }
        else
        {
            fireRateText.color = Color.black;
            countFireRate--;
        }
    }

    public void deathScreen()
    {
        death.SetActive(true);
    }
}
