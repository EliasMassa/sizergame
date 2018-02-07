using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeScript : MonoBehaviour
{
    public float xScale = 1;
    public float yScale = 1;
    public float yPosition;
    
    private float maxScale = 3;
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

        Debug.Log(Input.GetAxis("HorizontalMove"));

        HeightCheck();


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
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(gameObject.transform.position.x + (-transform.localScale.x / 2), transform.localScale.y), Vector2.up);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2 (gameObject.transform.position.x + (transform.localScale.x / 2), transform.localScale.y), Vector2.up);
        Debug.DrawRay(transform.position + (-transform.localScale / 2), Vector2.up, Color.green);
        Debug.DrawRay(transform.position + (transform.localScale / 2), Vector2.up, Color.green);
        if (hitLeft.collider != null || hitRight.collider != null)
        {

            if (hitLeft.point.y >= 2 && hitLeft.point.y < 3 || hitRight.point.y >= 2 && hitRight.point.y < 3)
            {
                maxScale = 2;

            }
            if (hitLeft.point.y >= 1 && hitLeft.point.y < 2 || hitRight.point.y >= 1 && hitRight.point.y < 2)
            {
                maxScale = 1;
            }
            else if (hitLeft.point.y >= 3 && hitRight.point.y >= 3)
            {
                maxScale = 3;
            }

        }
    }

}
