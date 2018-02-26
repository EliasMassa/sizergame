using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeScript : MonoBehaviour {

    public int eyeName;
    private float eyescale;
    private float maxScale = 3;
    private float playerPosX;
    private float playerPosY;
    private float playerScaleX;
    private float playerScaleY;
    private float eyeOffsetX = 0.2f;
    private float eyeOffsetY = 0.4f;
    private float mouthOffset = 0.4f;
    private float mouthScale;

    //Pelihahmon silmien ja suun animointi pelaajan sijainnin ja skaalan perusteella
	void Update()
    {
        if(eyeName == 1 || eyeName == 2)
        {
            transform.localScale = new Vector2(eyescale, eyescale);
        }
        else if(eyeName == 3)
        {
            transform.localScale = new Vector2(mouthScale, mouthScale);
        }

        if(eyescale > maxScale)
        {
            eyescale = maxScale;
        }
        if(mouthScale > maxScale)
        {
            mouthScale = maxScale;
        }

        playerPosX = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().transform.position.x;
        playerPosY = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().transform.position.y;
        playerScaleX = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().transform.localScale.x;
        playerScaleY = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().transform.localScale.y;

        if(playerScaleX > 2.2f && playerScaleY < 2.2f)
        {
            mouthOffset = 0.8f;
            mouthScale += 0.5f;
        }
        if (playerScaleX < 2 && playerScaleY < 2 || playerScaleX < 2 && playerScaleY > 2)
        {
            if (mouthScale == 1)
            {
                mouthOffset = 0.4f;
            }
            
        }
        if (playerScaleX < 2f)
        {
            mouthScale = 1;
        }

        if (playerScaleX > 2.2f && playerScaleY > 2.2f)
        {
            eyescale += 0.5f;
            mouthScale += 0.5f;
            eyeOffsetX = 0.8f;
            eyeOffsetY = 0.8f;
            mouthOffset = 1.5f;
        }
        else if (playerScaleX < 2.2f || playerScaleY < 2.2f)
        {
            eyescale = 1;
            eyeOffsetX = 0.2f;
            eyeOffsetY = 0.4f;

        }

        

        if (eyeName == 1)
        {
            transform.position = new Vector2(playerPosX - playerScaleX / 2 + eyeOffsetX, playerPosY + playerScaleY /2 - eyeOffsetY);
        }
        if (eyeName == 2)
        {
            transform.position = new Vector2(playerPosX + playerScaleX / 2 - eyeOffsetX, playerPosY + playerScaleY /2 - eyeOffsetY);
        }
        if (eyeName == 3)
        {
            transform.position = new Vector2(playerPosX, playerPosY - playerScaleY / 2 + mouthOffset);
        }
        
	}

}
