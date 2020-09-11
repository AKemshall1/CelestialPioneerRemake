using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStats : MonoBehaviour
{
    public Ship player;
    public UIManager uiManager;
    PlayerUtilities pu;
    //Collide with the power up
    //Set the new 

    public void Awake()
    {
        pu = gameObject.GetComponent<PlayerUtilities>();
    }
    public void PowerUpSpeed()
    {
        player.moveSpeed = pu.moveSpeed * 1.3f;
        uiManager.UpdateSpeedText();
        StartCoroutine("waitSpeed", 15);
    }
    IEnumerator waitSpeed(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.moveSpeed = pu.moveSpeed;
        uiManager.UpdateSpeedText();
    }
    public void PowerUpFireRate()
    {
        player.fireRate = pu.fireRate -0.111f;
        uiManager.UpdateFireRateText();
        StartCoroutine("waitFireRate", 15);
    }
    IEnumerator waitFireRate(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.fireRate = pu.fireRate;
        uiManager.UpdateFireRateText();
    }
    public void PowerUpDamage()
    {
        player.damage = pu.damage * 2;
        uiManager.UpdateDamageText();
        StartCoroutine("waitDamage", 15);
    }
    IEnumerator waitDamage(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.damage = pu.damage;
        uiManager.UpdateDamageText();
    }

}

