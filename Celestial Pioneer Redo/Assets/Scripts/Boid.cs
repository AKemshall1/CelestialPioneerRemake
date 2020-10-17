using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Boid : MonoBehaviour
{
    public Sprite[] possibleSprites = new Sprite[6];

    BoidsAlgorithm boidAl;
    Rigidbody2D rb;
    Vector2 force = Vector2.zero;
    Vector2 origin = Vector2.zero;
    Vector2 velStorage;
    LayerMask originMask = 1 << 4;

    int rand;
    public int myIndex;
    float velMag;

    public bool startedAttack;


    private void Start()
    {
        //Debug.Log(myIndex);
        int spriteNum = Random.Range(0, 6);
        boidAl = GameObject.FindGameObjectWithTag("BoidManager").GetComponent<BoidsAlgorithm>();
        gameObject.GetComponent<SpriteRenderer>().sprite = possibleSprites[spriteNum];
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (boidAl.attackingBoidsIndex.Count > 0)   //if the count is greater than one, some boids are trying to attack
        {
            if (!boidAl.attackingBoidsIndex.Contains(myIndex))
            {
                force += boidAl.CalculateForce(this.gameObject);
                rb.velocity = force;

                //Cap velocity
                velStorage = rb.velocity;
                velMag = rb.velocity.magnitude;

                if (velMag > 3.0f)
                {
                    velMag = 3.0f;
                    rb.velocity = velStorage.normalized * velMag;
                }
            }
        }
        else //if the attacking boids index is equal to 0 then no boids are trying to attack so calculate force 
        {
            //Debug.Log("Attacking boids index count is equal to zero:" + boidAl.attackingBoidsIndex.Count);
            force += boidAl.CalculateForce(this.gameObject);
            rb.velocity = force;

            //Cap velocity
            velStorage = rb.velocity;
            velMag = rb.velocity.magnitude;

            if (velMag > 3.0f)
            {
                velMag = 3.0f;
                rb.velocity = velStorage.normalized * velMag;
            }
        }






        //Randomly bring boid to the front or push back
        rand = Random.Range(1, 700);
        if (rand == 1)
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
            gameObject.transform.position = pos;
        }
        else if (rand == 2)
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
            gameObject.transform.position = pos;
        }
    }
}
