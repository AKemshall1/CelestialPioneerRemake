using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueShoot : MonoBehaviour
{
    public Ship enemyBlue;
    public GameObject blueBullet;
    public GameObject[] bulletArr = new GameObject[4];

    GameObject bulletStorage;
    GameObject bulletTemp;

    Vector2 bulletPos1, bulletPos2;

    float time = 0.0f;
    int bulletCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        bulletStorage = GameObject.FindWithTag("BulletStorage");    //find and cache the temporary spawn point for bullets - item pooling

        InitialiseBullets();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Shoot();
    }
    void InitialiseBullets()
    {
        for (int i = 0; i < 4; i++)
        {
            bulletTemp = Instantiate(blueBullet, bulletStorage.transform);
            bulletArr[i] = bulletTemp;
        }

    }

    void Shoot()
    {
        if (time >= enemyBlue.fireRate && gameObject.transform.position.y < enemyBlue.yTop && gameObject.transform.position.y > enemyBlue.yBot) //when the timer meets requirements and the enemy is on the screen
        {
            bulletPos1 = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y - 0.4f);    //vectors for where will shoot
            bulletPos2= new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y - 0.4f);

            bulletArr[bulletCount].transform.position = bulletPos1; //move bullet to position
            bulletArr[bulletCount].GetComponent<Rigidbody2D>().velocity = transform.up * enemyBlue.bulletSpeed; //move it forwards
            bulletCount++;

            if (bulletCount == 4)   //reset counter when needed
            {
                bulletCount = 1;
            }

            bulletArr[bulletCount].transform.position = bulletPos2;
            bulletArr[bulletCount].GetComponent<Rigidbody2D>().velocity = transform.up * enemyBlue.bulletSpeed;
            bulletCount++;

            if (bulletCount == 4)
            {
                bulletCount = 1;
            }

            time = 0;
        }

    }
}
