using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedShoot : MonoBehaviour
{
    public Ship enemyRed;
    public GameObject redBullet;
    public GameObject[] bulletArr = new GameObject[3];

    GameObject bulletStorage;
    GameObject bullet;

    float time = 0.0f;
    int bulletCount = 0;

    void Start()
    {


        bulletStorage = GameObject.FindWithTag("BulletStorage");
        InitialiseBullets();

        float rand = Random.Range(1.5f, 2.0f);
        //give the ship a random fire rate to make it easier to get through blocks of bullets
        enemyRed.fireRate = rand;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        time += Time.deltaTime;
    }
    void Shoot()
    {
        if (time >= enemyRed.fireRate && gameObject.transform.position.y < enemyRed.yTop && gameObject.transform.position.y > enemyRed.yBot)
        {
            //shoot a bullet and add to a counter
            //when the counter reaches 3, move the bullet from 2 places away back to the player
            Vector2 enemyRedPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f);

            bulletArr[bulletCount].transform.position = enemyRedPos;
            bulletArr[bulletCount].GetComponent<Rigidbody2D>().velocity = transform.right * enemyRed.bulletSpeed;
            bulletCount++;
            if (bulletCount == 3)
            {
                bulletCount = 1;
            }
            time = 0;
        }
    }


    void InitialiseBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            bullet = Instantiate(redBullet, bulletStorage.transform);
            bulletArr[i] = bullet;
        }
    }

}