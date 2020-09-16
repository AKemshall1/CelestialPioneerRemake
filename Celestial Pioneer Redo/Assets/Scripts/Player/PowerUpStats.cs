using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStats : MonoBehaviour
{
    public Ship player;
    public UIManager uiManager;
    PlayerUtilities pu;

    public bool hasDamageUp, hasSpeedUp, hasFireUp;


    //Collide with the power up
    //Set the new 

    public void Awake()
    {
        pu = gameObject.GetComponent<PlayerUtilities>();
    }
    public void PowerUpSpeed()
    {
        hasSpeedUp = true;
        player.moveSpeed = pu.moveSpeed * 1.3f;
        uiManager.UpdateSpeedText();
        StartCoroutine("waitSpeed", 15);
    }
    IEnumerator waitSpeed(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.moveSpeed = pu.moveSpeed;
        uiManager.UpdateSpeedText();
        hasSpeedUp = false;
    }
    public void PowerUpFireRate()
    {
        hasFireUp = true;
        player.fireRate = pu.fireRate -0.111f;
        uiManager.UpdateFireRateText();
        StartCoroutine("waitFireRate", 15);
      
    }
    IEnumerator waitFireRate(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.fireRate = pu.fireRate;
        uiManager.UpdateFireRateText();
        hasFireUp = false;
    }
    public void PowerUpDamage()
    {
        hasDamageUp = true;
        player.damage = pu.damage * 2;
        uiManager.UpdateDamageText();
        StartCoroutine("waitDamage", 15);
    }
    IEnumerator waitDamage(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.damage = pu.damage;
        uiManager.UpdateDamageText();
        hasDamageUp = false;
    }

}

