using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyYellowMovement : MonoBehaviour
{
    public Ship enemyYellow;
    GameObject player;
    Vector3 targetPos;
    float xPos, yPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        targetPos = player.transform.position;

        float angle = Mathf.Atan2(player.transform.position.x, player.transform.position.z) * Mathf.Rad2Deg;
        transform.rotation = new Quaternion(0, 0, transform.rotation.z + angle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly move downwards
        //In the X axis direction of the player position cached.

        

        transform.position = Vector3.MoveTowards(transform.position, targetPos, enemyYellow.moveSpeed);

    }

    public Vector3 GetTargetPosition()
    {
        if (targetPos != null)
            return targetPos;
        else
        {
            Debug.LogError("EnemyYellowMovement: Failed to get target position. Using 0,0,0.");
            return new Vector3(0, 0, 0);
        }
           
        
    }
}
