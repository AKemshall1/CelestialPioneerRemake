using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowUtility : MonoBehaviour
{
    public Ship enemyYellow;
    // Start is called before the first frame update
    void Start()
    {
        enemyYellow.health = 20;
        enemyYellow.lives = 0;
        enemyYellow.damage = 30;
        enemyYellow.moveSpeed = 0.008f;
        enemyYellow.bulletSpeed = 0.0f;
        enemyYellow.fireRate = 0.0f;
        enemyYellow.score = 0;
        enemyYellow.xLeft = -2.8f;
        enemyYellow.xRight = 6.23f;
        enemyYellow.yBot = -4.8f;
        enemyYellow.yTop = 4.8f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
