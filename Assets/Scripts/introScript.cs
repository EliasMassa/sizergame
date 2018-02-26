using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour {

    //Rajoitetaan pelin alun kappaleiden liikkumista y-akselilla
	void Update ()
    {
        transform.position = new Vector2(transform.position.x, 14.5f);
	}
}
