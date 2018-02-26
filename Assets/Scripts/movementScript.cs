using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour {


    private Rigidbody2D rb2d;
    public float maxSpeed = 5f;
    private float moveForce = 300f;

    private float hMovement;

    //Peli lisää voimia pelihahmoon HorizontalMove-akselin muutoksien mukaan 
    private void CheckInput()
    {
        hMovement = Input.GetAxis("HorizontalMove");
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        CheckInput();

        if (hMovement * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * hMovement * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(hMovement * maxSpeed, rb2d.velocity.y);
        }
    }
}
