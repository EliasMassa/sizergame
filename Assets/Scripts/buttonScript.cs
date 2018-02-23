using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public float gravity = 1;
    public float xPosition = 0;
    public float minHeight = 0;
    public float maxHeight = 0;
    public bool TriggerActive = false;

    
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
        if (doorname == "Door2")
        {
            if (other.CompareTag("Trigger") || other.CompareTag("Trigger2"))
            {
                TriggerActive = true;
            }


            DoorCheck();
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        TriggerActive = false;    
    }

    void DoorCheck()
    {

        if (GameObject.Find("Button (2)").GetComponent<buttonScript>().TriggerActive && GameObject.Find("Button (3)").GetComponent<buttonScript>().TriggerActive)
        {
            GameObject.FindGameObjectWithTag(doorname).GetComponent<Rigidbody2D>().gravityScale = -0.5f;
            Destroy(GameObject.Find("Button (2)"));
            Destroy(GameObject.Find("Button (3)"));
        }
    }


}
