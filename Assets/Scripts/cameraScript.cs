using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    private float playerPositionX;
    private float playerPositionY;


    private void Update()
    {
        

    }

    void FixedUpdate ()
    {
        //playerPositionX = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().position.x;
        //playerPositionY = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().position.y;
        //transform.position = new Vector3(playerPositionX, playerPositionY, -1);
    }
}
