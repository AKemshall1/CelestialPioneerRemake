using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
   

    // Start is called before the first frame update

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.001f);
        if (gameObject.transform.position.y >= 20.0f)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, 0.0f);
    }
}
