using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlattform : MonoBehaviour
{
    public float moveSpeed = 3f;
    bool moveRight = true;
    
    public float leftEndX;
    public float rightEndX;

    void Update()
    {
        if(transform.localPosition.x > rightEndX){
            moveRight= false;
        }
        if(transform.localPosition.x < leftEndX)
        {
            moveRight = true;
        }

        if(moveRight)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + moveSpeed * Time.deltaTime, transform.localPosition.y);
        }else
        {
            transform.localPosition = new Vector2(transform.localPosition.x - moveSpeed * Time.deltaTime, transform.localPosition.y);
        }
    }
}
