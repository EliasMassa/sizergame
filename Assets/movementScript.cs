using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{

  
    void Start()
    {
        
    }

 
    void FixedUpdate()
    {

        transform.Translate(Input.GetAxis("HorizontalMove") * 0.25f, 0, 0);

        //if (Input.GetAxis("HorizontalMove") > 0)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(Vector2.right);
        //}

        //if (Input.GetAxis("HorizontalMove") < 0)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(Vector2.left);
        //}




    }
}
