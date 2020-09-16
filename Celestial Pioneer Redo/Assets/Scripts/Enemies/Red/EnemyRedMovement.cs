using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedMovement : MonoBehaviour
{
    public Ship enemyRed;
    Vector2 startPos;

    EnemyRedUtility uti;

    float xPos, yPos;

    void Start()
    {
        startPos = transform.position;  //store the initial position to offset the sin movement later on
        uti = gameObject.GetComponent<EnemyRedUtility>();
    }
    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        //move down the screen in a sin wave
        //move thing side to side on the x axis, multiplication number changes the speed at which it moves left right
        xPos = Mathf.Sin(0.5f * Time.time);
        yPos = transform.position.y - enemyRed.moveSpeed; //move the enemy down graduall
        transform.position = new Vector2(startPos.x + xPos, yPos);

        if (transform.position.y <= enemyRed.yBot)
        {
            uti.DestroyBullets();
            Destroy(this.gameObject);
        }
    }
}
