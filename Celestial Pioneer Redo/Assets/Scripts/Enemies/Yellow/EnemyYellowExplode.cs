using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellowExplode : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyYellowMovement movement;
    public Sprite explosionSprite;
    void Start()
    {
        movement = GetComponent<EnemyYellowMovement>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movement.GetTargetPosition())
        {
            Explode();     
        }
    }

   public  void Explode()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite != explosionSprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        }
        if (gameObject.GetComponent<Animator>() == null)
        {
            gameObject.AddComponent<Animator>();
            gameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("YellowExplode") as RuntimeAnimatorController;
        }
        StartCoroutine("waitAnimEnd");
      
       
          
    }

    IEnumerator waitAnimEnd()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
