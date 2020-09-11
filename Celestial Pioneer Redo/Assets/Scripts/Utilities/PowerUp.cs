using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Vector2 pos;
    float yMax = -5.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector2(transform.position.x, transform.position.y - 0.001f);
        if (transform.position.y <= yMax)
        {
            //Destroy(this.gameObject);
        }
    }
}
