using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities : MonoBehaviour
{
	public Ship player;

	public int health, damage, lives;
	public float moveSpeed, fireRate;


    private void Awake()
	{ 		//reset all player attributes that can change during the game

		player.health = 100;
		player.damage = 10;
		player.lives = 3;
		player.score = 0;
		player.moveSpeed = 5;
		player.fireRate = 0.333f;

		damage = player.damage;
		moveSpeed = player.moveSpeed;
		fireRate = player.fireRate;
		health = player.health;
		lives = player.lives;
	}
}
