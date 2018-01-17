using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeScript : MonoBehaviour
{
    public float xScale = 1;
    public float yScale = 1;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.localScale = new Vector3(xScale, yScale, 1);

        if (Input.GetAxisRaw("Horizontal") > 0 && xScale < 3)
        {
            xScale += 0.1f;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            xScale = 0;
        }

        if (Input.GetAxisRaw("Vertical") > 0 && yScale < 3)
        {
            yScale += 0.1f;
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            yScale = 0;
        }

        if (xScale > 3)
        {
            xScale = 3;
        }

        if (xScale < 1)
        {
            xScale = 1;
        }

        if (yScale > 3)
        {
            yScale = 3;
        }

        if (yScale < 1)
        {
            yScale = 1;
        }

    }

}
