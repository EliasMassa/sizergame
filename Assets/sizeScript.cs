using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeScript : MonoBehaviour
{
    public float xScale = 1;
    public float yScale = 1;
    public float yPosition;
    
    private float maxScale = 3;
    private float maxWidthScale = 3;
    private Vector2 direction;
    private int speed = 5;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity = transform.forward * Input.GetAxis("HorizontalMove") * 100 * Time.deltaTime;
        direction = Vector2.right;
        direction = new Vector2(Input.GetAxis("HorizontalMove") * 100 * Time.deltaTime, 0);
        direction.Normalize();
        transform.Translate(direction * Time.deltaTime * speed);


        HeightCheck();
        WidthCheck();


        yPosition = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        transform.localScale = new Vector3(xScale, yScale, 1);

        if (Input.GetAxisRaw("Horizontal") > 0 && xScale <= maxWidthScale)
        {
            Mathf.Clamp(xScale, 1f, 3f);
            xScale += 0.1f;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            xScale = 1;
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            yScale = 1f;

        }

        if (Input.GetKeyUp("up"))
        {

            UpVertical();
        }

        if (Input.GetAxisRaw("Vertical") > 0 && yScale <= maxScale)
        {
            Mathf.Clamp(yScale, 1f, 3f);
            yScale += 0.1f;
            
        }

        

        if (yScale > maxScale)
        {
            yScale = maxScale;
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


        if (hitLeft.collider != null || hitRight.collider != null)
        {

            if (hitLeft.point.y - transform.position.y > 1 && hitLeft.point.y - transform.position.y <= 1.6 || hitRight.point.y - transform.position.y > 1 && hitRight.point.y - transform.position.y <= 1.6)
            {
                maxScale = 2;

            }
            if (hitLeft.point.y - transform.position.y > 0 && hitLeft.point.y - transform.position.y <= 1 || hitRight.point.y - transform.position.y >= 0 && hitRight.point.y - transform.position.y <= 1)
            {
                maxScale = 1;
            }
            else if (hitLeft.point.y - transform.position.y > 1.8 && hitRight.point.y - transform.position.y > 1.8)
            {
                maxScale = 3;
            }

        }
    }
    void WidthCheck()
    {
        RaycastHit2D LowerHitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2), Vector2.left);
        RaycastHit2D LowerHitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2), Vector2.right);

        RaycastHit2D upperHitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2), Vector2.left);
        RaycastHit2D upperHitRight = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2), Vector2.right);

        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2), Vector2.left, Color.blue);
        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - transform.localScale.y / 2), Vector2.right, Color.blue);

        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2), Vector2.left, Color.blue);
        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + transform.localScale.y / 2), Vector2.right, Color.blue);

        Debug.Log(LowerHitRight.point.x - LowerHitLeft.point.x);
        Debug.Log(upperHitRight.point.x - upperHitLeft.point.x);

        if (LowerHitLeft.collider != null || LowerHitRight.collider != null)
        {

            if (LowerHitRight.point.x - LowerHitLeft.point.x < 2.8 && LowerHitRight.point.x - LowerHitLeft.point.x >= 1.2 && upperHitRight.point.x - upperHitLeft.point.x < 2.8 && upperHitRight.point.x - upperHitLeft.point.x >= 1.2)
            {
                maxWidthScale = 2;

            }
            if (LowerHitRight.point.x - LowerHitLeft.point.x < 2 && upperHitRight.point.x - upperHitLeft.point.x < 2)
            {
                maxWidthScale = 1;

            }
            if (LowerHitRight.point.x - LowerHitLeft.point.x > 2.8 && upperHitRight.point.x - upperHitLeft.point.x > 2.8)
            {
                maxWidthScale = 3;

            }


        }
    }

}
