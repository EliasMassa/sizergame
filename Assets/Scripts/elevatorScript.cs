using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorScript : MonoBehaviour
{

    public AnimationCurve myCurve;

    //Hissi liikkuu käyrän mukaisesti ylös ja alas
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, myCurve.Evaluate((Time.time + myCurve.length)));
    }

}
