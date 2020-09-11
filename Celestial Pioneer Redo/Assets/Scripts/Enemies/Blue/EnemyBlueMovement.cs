using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueMovement : MonoBehaviour
{
    public Ship enemyBlue;
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float xPos = transform.position.x + (enemyBlue.moveSpeed + 0.001f);
        float yPos = transform.position.y - enemyBlue.moveSpeed; //move the enemy down gradually
        transform.position = new Vector2(xPos, yPos);

        if (transform.position.x >= enemyBlue.xRight)
        {
            transform.position = new Vector2(enemyBlue.xLeft, transform.position.y);
        }

        if (transform.position.y <= enemyBlue.yBot)
        {
            //DestroyBullets();
            Destroy(this.gameObject);
        }
    }
}
