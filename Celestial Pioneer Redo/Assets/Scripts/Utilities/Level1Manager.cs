using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1Manager : MonoBehaviour
{
    //generate arrays of enemies in formations
    float timerRed, timerBlue, timerRand, timerYellow;
    public GameObject enemyRed, enemyBlue, enemyYellow;

    const float ySpawn = 5.2f;
    const float xLeft = -1.3f;
    const float xLeftRed = 0.0f;
    const float xRight = 5.5f;
    const float xRightRed = 4.23f;
    const float delayRed = 10.0f;
    const float delayYellow = 6.0f;
    const float delayBlue = 8.0f;
    const float delayRand = 20.0f;

    Vector2[] circleTransforms = new Vector2[8];
    public GameObject[] redShips;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnRedCircle();
       
    }

    // Update is called once per frame
    private void Update() {
        timerRed += Time.deltaTime;
    
        timerBlue += Time.deltaTime;
      
        timerYellow += Time.deltaTime;



        if (timerRed >= delayRed)
        {
            SpawnRedCircle();
            timerRed = 0.0f;
        }
        if (timerBlue >= delayBlue)
        {
            SpawnBlue();
            timerBlue = 0.0f;
        }
        if (timerYellow >= delayYellow)
        {
            SpawnYellow();
            timerYellow = 0.0f;
        }
        if (timerRand >= delayRand)
        {
            SpawnRandomEnemy();
            timerRand = 0.0f;
        }


    }


    private void SpawnRandomEnemy()
    {
        int rand = Random.Range(1, 4);

        switch (rand)
        {
            case 1:
                SpawnRedCircle();
                break;
            case 2:
                SpawnYellow();
                break;
            case 3:
                SpawnBlue();
                break;
            
        }
    }


    //Red enemy formations - sine waves shooting forwards

    private void SpawnRedCircle()
    {
        List<int> usedPos = new List<int>();    //dynamic list showing which positions have already been used
 

        float baseX = Random.Range(xLeftRed, xRightRed);  //where to base the enemy formation
        int shipNum = Random.Range(2, 9);   //how many ships are in the formation
        bool posFound = false;  //whether a position has been deternined. is reset for each ship


        redShips = new GameObject[shipNum]; //initialise ship gameobject array with the right number

        circleTransforms[0] = new Vector2(baseX + 0.8f, ySpawn); // right
        circleTransforms[1] = new Vector2(baseX - 0.8f, ySpawn); // left
        circleTransforms[2] = new Vector2(baseX, ySpawn + 0.8f); // up
        circleTransforms[3] = new Vector2(baseX, ySpawn - 0.8f); // down

        circleTransforms[4] = new Vector2(baseX + 0.3f, ySpawn + 0.3f); // top right
        circleTransforms[5] = new Vector2(baseX - 0.3f, ySpawn + 0.3f); // top left
        circleTransforms[6] = new Vector2(baseX + 0.3f, ySpawn - 0.3f); // bottom right
        circleTransforms[7] = new Vector2(baseX - 0.3f, ySpawn - 0.3f); // bottom left

        Debug.Log("There are " + redShips.Length + "ships to be spawned");

        //iterate through the ships and apply a random transform to it

        for (int i = 0; i < redShips.Length; i++)
        {
            int rand = Random.Range(0, 8);  //generate a random number relating to the transform array
            redShips[i] = Instantiate(enemyRed);

            while (!posFound)
            {
                if (!usedPos.Contains(rand))    //if the number hasnt already been used
                {
                    redShips[i].transform.position = circleTransforms[rand];    //use it 
                    usedPos.Add(rand);  //add it to the used list

                    posFound = true;
                }
                else
                    rand = Random.Range(0, 8);  //if it has already been used generate a new one
            }

            posFound = false; //out of the loop so a position has been found - reset it for the next loop
        }

    }

    private void SpawnYellow()
    {
        float randX = Random.Range(xLeft, xRight);
        Vector2 spawnPos = new Vector2(randX, ySpawn);

        GameObject enemy = Instantiate(enemyYellow);
        enemy.transform.position = spawnPos;
    }

    private void SpawnBlue()
    {
        GameObject enemy = Instantiate(enemyBlue);
        enemy.transform.position = new Vector2(xLeft, ySpawn);
    }
}
