using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public float gravity = 1;
    public float xPosition = 0;
    public float minHeight = 0;
    public float maxHeight = 0;
    private bool leftTriggerActive = false;
    private bool rightTriggerActive = false;
    
    public string doorname;

    void Update()
    {
        transform.position = new Vector2(xPosition, Mathf.Clamp(transform.position.y, minHeight, maxHeight));

      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (doorname != "Door2")
        {
            GetComponent<Rigidbody2D>().gravityScale = gravity;
            GameObject.FindGameObjectWithTag(doorname).GetComponent<Rigidbody2D>().gravityScale = -0.5f;

            Destroy(gameObject);
        }
        else if (doorname == "Door2")
        {
            if (other.CompareTag("Trigger"))
            {
                Debug.Log("left");
                leftTriggerActive = true;
            }
            if (other.CompareTag("Trigger2"))
            {
                Debug.Log("right");
                rightTriggerActive = true;
            }

            DoorCheck();
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Trigger"))
        {
            leftTriggerActive = false;
        }
        if (col.CompareTag("Trigger2"))
        {
            rightTriggerActive = false;
        }
    }

    void DoorCheck()
    {
        if (leftTriggerActive == true && rightTriggerActive == true)
        {
            Debug.Log("kikkel");
            GameObject.FindGameObjectWithTag(doorname).GetComponent<Rigidbody2D>().gravityScale = -0.5f;
        }
    }


}
