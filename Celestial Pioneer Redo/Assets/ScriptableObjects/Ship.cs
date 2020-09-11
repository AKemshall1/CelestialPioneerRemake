using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShip", menuName = "Ship")]
public class Ship : ScriptableObject
{
    public int health;
    public int damage;
    public int lives;
    public int score;
    
    public float fireRate;
    public float moveSpeed;
    public float bulletSpeed;

    public float yTop = 4.8f;
    public float yBot = -4.8f;
    public float xLeft = -2.8f;
    public float xRight = 6.23f;



}

