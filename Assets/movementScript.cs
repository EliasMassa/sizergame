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
    }
}
