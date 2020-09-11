using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowMovement : MonoBehaviour
{
    public Ship enemyYellow;
    private EnemyYellowUtility uti;

    float yPos;

    // Start is called before the first frame update
    void Start()
    {
        uti = gameObject.GetComponent<EnemyYellowUtility>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!uti.dead)  //move if not dead
        {
            Movement();
        }
    }

    private void Movement()
    {
        yPos = transform.position.y - enemyYellow.moveSpeed; //move the enemy down gradually
        transform.position = new Vector2(transform.position.x, yPos);

        if (transform.position.y <= enemyYellow.yBot)   //when reaching the end of the screen, we havent hit the player so explode without damaging the player
        {
            uti.hitPlayer = false;
            uti.Explode(uti.hitPlayer);
        }
    }
}
