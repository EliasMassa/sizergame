using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeScript : MonoBehaviour
{
    private float xScale = 1;
    private float yScale = 1;
    
    
    private float maxScale = 2.95f;
    private float maxWidthScale = 2.95f;
 
    private Rigidbody2D rb2d;
    public float maxSpeed = 5f;
    private float moveForce = 300f;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {


        float h = Input.GetAxis("HorizontalMove");
        

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
   
        HeightCheck();
        WidthCheck();


        

        transform.localScale = new Vector3(xScale, yScale, 1);

        if (Input.GetAxisRaw("Horizontal") > 0 && xScale <= maxWidthScale)
        {
            Mathf.Clamp(xScale, 1f, 3f);
            xScale += 0.1f;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            xScale = 0.95f;
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            yScale = 0.95f;

        }

        if (Input.GetKeyUp("up"))
        {

            UpVertical();
        }

        if (Input.GetAxisRaw("Vertical") > 0 && yScale <= maxScale)
        {
            Mathf.Clamp(yScale, 0.95f, 2.95f);
            yScale += 0.1f;
            
        }

        

        if (yScale > maxScale)
        {
            yScale = maxScale;
        }

        if (xScale > maxWidthScale)
        {
            xScale = maxWidthScale;
        }

        
    }


    void UpVertical()
    {
        transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, (GameObject.FindGameObjectWithTag("Player").transform.position.y + (GameObject.FindGameObjectWithTag("Player").transform.localScale.y/1.5f) * Time.deltaTime));
    }

    void HeightCheck()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x + (-transform.localScale.x / 2), gameObject.transform.position.y + transform.localScale.y/2), Vector2.up);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2 (gameObject.transform.position.x + (transform.localScale.x / 2), gameObject.transform.position.y + transform.localScale.y/2), Vector2.up);

        Debug.DrawRay(new Vector2(gameObject.transform.position.x + (-transform.localScale.x / 2), gameObject.transform.position.y + transform.localScale.y / 2), Vector2.up, Color.green);
        Debug.DrawRay(new Vector2(gameObject.transform.position.x + (transform.localScale.x / 2), gameObject.transform.position.y + transform.localScale.y / 2), Vector2.up, Color.green);

        //Debug.Log(hitLeft.point.y - transform.position.y);
        if (hitLeft.collider != null || hitRight.collider != null)
        {

            if (hitLeft.point.y - transform.position.y > 1 && hitLeft.point.y - transform.position.y <= 1.6 || hitRight.point.y - transform.position.y > 1 && hitRight.point.y - transform.position.y <= 1.6)
            {
                maxScale = 1.95f;

            }
            if (hitLeft.point.y - transform.position.y > 0 && hitLeft.point.y - transform.position.y <= 1 || hitRight.point.y - transform.position.y >= 0 && hitRight.point.y - transform.position.y <= 1)
            {
                maxScale = 0.95f;
            }
            if (hitLeft.point.y - transform.position.y > 1.5 && hitRight.point.y - transform.position.y > 1.5)
            {
                maxScale = 2.95f;
            }

        }
    }
    void WidthCheck()
    {
        //Alemmat castit
        RaycastHit2D LowerHitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2 + 0.1f), Vector2.left);
        RaycastHit2D LowerHitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2 + 0.1f), Vector2.right);

        //Keskellä
        RaycastHit2D middleHitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Vector2.left);
        RaycastHit2D middleHitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Vector2.right);

        //Ylemmät
        RaycastHit2D upperHitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2 - 0.1f), Vector2.left);
        RaycastHit2D upperHitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2 - 0.1f), Vector2.right);

        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2), Vector2.left, Color.blue);
        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2), Vector2.right, Color.blue);

        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Vector2.left, Color.blue);
        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Vector2.right, Color.blue);

        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2), Vector2.left, Color.blue);
        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2), Vector2.right, Color.blue);

        //Debug.Log(LowerHitRight.point.x - LowerHitLeft.point.x);
        //Debug.Log(upperHitRight.point.x - upperHitLeft.point.x);
        //Debug.Log(middleHitRight.point.x - middleHitLeft.point.x);

        if (LowerHitLeft.collider != null || LowerHitRight.collider != null)
        {

            if (LowerHitRight.point.x - LowerHitLeft.point.x < 2.5 && LowerHitRight.point.x - LowerHitLeft.point.x > 1.4 || upperHitRight.point.x - upperHitLeft.point.x < 2.5 && upperHitRight.point.x - upperHitLeft.point.x > 1.4 || middleHitRight.point.x - middleHitLeft.point.x < 2.5 && middleHitRight.point.x - middleHitLeft.point.x > 1.4)
            {
                maxWidthScale = 1.95f;

            }
            if (LowerHitRight.point.x - LowerHitLeft.point.x < 1.1 || upperHitRight.point.x - upperHitLeft.point.x < 1.1 || middleHitRight.point.x - middleHitLeft.point.x < 1.1)
            {
                maxWidthScale = 0.95f;

            }
            if (LowerHitRight.point.x - LowerHitLeft.point.x > 2.5 && upperHitRight.point.x - upperHitLeft.point.x > 2.5 && middleHitRight.point.x - middleHitLeft.point.x > 2.5)
            {
                maxWidthScale = 2.95f;

            }


        }
    }

}
