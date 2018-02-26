using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    private GameObject player;

    //Kamera seuraa pelihahmon koordinaatteja
    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate ()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
    }
}
