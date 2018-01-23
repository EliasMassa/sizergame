using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeScript : MonoBehaviour
{
    public float xScale = 1;
    public float yScale = 1;
    public float yPosition;

    

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        //transform.position = new Vector2(1, (GameObject.FindGameObjectWithTag("Player").transform.position.y + 2.5f));

        yPosition = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        transform.localScale = new Vector3(xScale, yScale, 1);

        if (Input.GetAxisRaw("Horizontal") > 0 && xScale <= 3)
        {
            Mathf.Clamp(xScale, 1f, 3f);
            xScale += 0.1f;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            xScale = 1;
        }

        if (Input.GetAxisRaw("Vertical") > 0 && yScale <= 3)
        {
            Mathf.Clamp(yScale, 1f, 3f);
            yScale += 0.1f;
            
        }

        if (Input.GetAxisRaw("Vertical") == 0 && yScale > 1)
        {
            Mathf.Clamp(yScale, 1f, 3f);
            yScale = 1f;
            
        }

        if (Input.GetKeyUp("up"))
        {

            UpVertical();
        }
    }

    void UpVertical()
    {
        transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, (GameObject.FindGameObjectWithTag("Player").transform.position.y + (GameObject.FindGameObjectWithTag("Player").transform.localScale.y/3f)));
    }

}
