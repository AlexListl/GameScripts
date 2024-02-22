using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlattformY : MonoBehaviour
{
    public float maxY;
    public float minY;
    bool moveUpwards = true;
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y > maxY)
        {
            moveUpwards= false;
        }
        if(transform.localPosition.y < minY)
        {
            moveUpwards = true;
        }

        if(moveUpwards)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + moveSpeed * Time.deltaTime);
        }else
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - moveSpeed * Time.deltaTime);
        }
    }
}
