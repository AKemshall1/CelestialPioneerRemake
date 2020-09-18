using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	float time = 0.0f;
	int bulletCount = 0;

	InputMaster controls;

	public GameObject playerBullet, bulletStorage;
	GameObject[] bulletArr = new GameObject[8];
	public Ship player;

	private void OnEnable()
	{
		controls.Enable();
	}

	private void OnDisable()
	{
		controls.Disable();
	}
    private void Awake()
    {
		controls = new InputMaster();
		controls.Player.Shoot.performed += context => Shoot();

		InitialiseBullets();
	}

    private void Update()
    {
		time += Time.deltaTime;
    }
    void InitialiseBullets()
	{
		for (int i = 0; i < 8; i++)
		{
			GameObject bullet = Instantiate(playerBullet, bulletStorage.transform);
			bullet.transform.rotation = new Quaternion(0, 0, 90, 0);

			bulletArr[i] = bullet;
		}
	}

	void Shoot()
	{
		if (time >= player.fireRate)
		{
			//shoot a bullet
			//add to a counter
			//when the counter reaches 3, move the bullet from 2 places away back to the player
			Vector2 playerPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.4f);

			bulletArr[bulletCount].transform.position = playerPos;
			bulletArr[bulletCount].GetComponent<Rigidbody2D>().velocity = transform.right * player.bulletSpeed;
			bulletCount++;
			if (bulletCount == 8)
			{
				bulletCount = 1;
			}
			time = 0;
		}
	}
}
