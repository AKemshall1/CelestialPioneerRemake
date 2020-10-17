//Modified boid algorithm to make a moving ball
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Video;

public class BoidsAlgorithm : MonoBehaviour
{
    private const int boidNum = 10;

    public GameObject[] boidArr = new GameObject[boidNum];
    private Vector2[] tripleShotOGPos = new Vector2[3];
    private Rigidbody2D boidRb;
    private Vector2 finalForce = Vector2.zero;
    private Vector2 finalVecC = Vector2.zero;
    private Vector2 finalVecS = Vector2.zero;
    private Vector2 finalVecA = Vector2.zero;
    private Vector2 centerOfMass = Vector2.zero;
    private Vector2 finalVec = Vector2.zero;
    private Vector2 boidOgPos = Vector2.zero;

    public GameObject boidPrefab;

    public List<int> attackingBoidsIndex = new List<int>(0);
    public List<int> boidNumList = new List<int>(boidNum);
    private bool attackInProgress = false;
    private bool goingDown = true;
    private float time = 0.0f;

    public float x, y;
    public int randBoidIndex;

    void Start()
    {
        // Debug.Log(boidNum);
        //Instantiate boids into the array for later use
        for (int i = 0; i < boidNum; i++)
        {
            //Debug.Log(boidNum);
            float x = Random.Range(-1.0f, 1.0f);
            float y = Random.Range(-1.0f, 1.0f);
            Vector2 place = new Vector2(x, y);
            boidArr[i] = Instantiate(boidPrefab, place, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            boidArr[i].gameObject.GetComponent<Boid>().myIndex = i;
        }
        PrepareTriple();
    }

    private void Update()
    {
        //time += Time.deltaTime;
        AttackTriple();
    }


    public Vector2 CalculateForce(GameObject calledFrom)
    {
        finalForce = Vector2.zero;
        finalVecC = Vector2.zero;
        finalVecS = Vector2.zero;
        finalVecA = Vector2.zero;
        //________________________COHESION____________________________//
        //1. Reset the number of neighbours and center of mass
        centerOfMass = Vector2.zero;
        finalVec = Vector2.zero;

        for (int i = 0; i < boidNum; i++)
        {
            if (boidArr[i] == calledFrom)
            {
                continue;
            }

            CenterOfMass(calledFrom);
            Seperation(calledFrom, i);
            Alignment(i);

        }

        finalForce = finalVecA + finalVecC + finalVecS;

        return finalForce;
    }

    //_______BOIDS ALGORITHM METHODS_________
    private void CenterOfMass(GameObject calledFrom)
    {
        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(-0.0f, 0.5f);
        centerOfMass = new Vector2(x, y);
        finalVec = centerOfMass - (Vector2)calledFrom.transform.position;
        finalVecC += finalVec;
    }
    private void Seperation(GameObject calledFrom, int i)
    {
        if (Vector2.Distance(calledFrom.transform.position, boidArr[i].transform.position) < 1.0f)
        {
            finalVecS -= (Vector2)calledFrom.transform.position - (Vector2)boidArr[i].transform.position;
        }
    }
    private void Alignment(int i)
    {
        finalVec += boidArr[i].GetComponent<Rigidbody2D>().velocity;
        finalVecA /= (boidNum - 1);
        finalVecA /= 100;
    }

    //_____________ATTACK PATTERNS____________
    //1. Move down fast, pause, then move back up

    private void CheckIfPingPong()
    {
        randBoidIndex = Random.Range(0, boidNum);  //generate a new random boid
        boidRb = boidArr[randBoidIndex].GetComponent<Rigidbody2D>();    //store its rigidbody for later use
        boidRb.velocity = Vector2.zero; //reset velocity ready for new values
        boidRb.angularVelocity = 0;
        boidOgPos = boidArr[randBoidIndex].transform.position;  //store the current position so it knows where to return to later

        attackInProgress = true;
        goingDown = true;   //reset the bool for use in the ping pong movement
        attackingBoidsIndex.Clear();
        attackingBoidsIndex.Add(randBoidIndex);

    }

    private void PingPong()
    {
        if (boidArr[randBoidIndex].transform.position.y >= (boidOgPos.y - 5) && goingDown)    //if the boid hasn't reached the spot it needs too
        {
            boidRb.velocity = Vector3.zero;
            boidRb.angularVelocity = 0;
            boidRb.velocity = new Vector2(0, -2) * 2;
        }
        else if (boidArr[randBoidIndex].transform.position.y <= (boidOgPos.y - 5)) //reached position so should move up
        {
            goingDown = false;
            boidRb.velocity = new Vector2(0, 2) * 2;
        }
        else if (boidArr[randBoidIndex].transform.position.y > boidOgPos.y)
        {
            boidRb.velocity = Vector3.zero;
            boidRb.angularVelocity = 0;
            time = 0.0f;
            attackInProgress = false;
            attackingBoidsIndex.Clear();
        }
    }

    void PrepareTriple()
    {
        goingDown = true; //reset bool used for movement
        chooseRandomBoid(3);
        for (int i = 0; i < attackingBoidsIndex.Count; i++)
        {
            boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = Vector2.zero;//reset velocities
            boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().angularVelocity = 0;
            if (i > 0)  //move all boids to the same pos as the first in the series
            {
                boidArr[attackingBoidsIndex[i]].transform.position = boidArr[attackingBoidsIndex[0]].transform.position;    //move all boids together
                boidOgPos = boidArr[attackingBoidsIndex[0]].transform.position; //store this position
            }

        }
    }
    void AttackTriple()
    {
        for (int i = 0; i < attackingBoidsIndex.Count; i++)
        {
            if (goingDown && boidArr[attackingBoidsIndex[i]].transform.position.y >= (tripleShotOGPos[i].y - 5.0f))
            {
                //Debug.Log("Going down");
                if (i == 0)
                {
                    //left
                    boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f,-1.0f);

                }
                else if (i == 1)
                {
                    //middle
                    boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -1.0f);
                }
                else if (i == 2)
                {
                    //right
                    boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, -1.0f);

                }
            }
            else if (boidArr[attackingBoidsIndex[i]].transform.position.y <= (tripleShotOGPos[i].y - 5.0f))
            {
                //Debug.Log("Going up");
                goingDown = false;
                if (i == 0)
                {
                    //left
                    boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 1.0f);
                }
                else if (i == 1)
                {
                    //middle
                    boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 1.0f);
                }
                else if (i == 2)
                {
                    //right
                    boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 1.0f);
                }
            }
            else if (boidArr[attackingBoidsIndex[i]].transform.position.y > tripleShotOGPos[i].y)
            {
                //Debug.Log("stopped");
                boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                boidArr[attackingBoidsIndex[i]].GetComponent<Rigidbody2D>().angularVelocity = 0;
                time = 0.0f;
                attackInProgress = false;
                attackingBoidsIndex.Clear();
            }
        }
    }

    void chooseRandomBoid(int amountChoose)
    {
        attackingBoidsIndex.Clear();
        bool foundRand;

        //fill an array with all the boid nums
        //pick a random one
        //remove it
        //choose again
        for (int i = 0; i < amountChoose; i++)
        {
            foundRand = false;
            while (!foundRand)
            {
                //Choose random number
                int randBoid = Random.Range(0, boidNum);
                if (!attackingBoidsIndex.Contains(randBoid))
                {
                    attackingBoidsIndex.Add(randBoid);
                    foundRand = true;
                    Debug.Log(randBoid);
                }
                else
                    continue;
            }
        }
    }
}
