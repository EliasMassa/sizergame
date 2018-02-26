using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorDestoyer : MonoBehaviour
{
    //Ovi tuhotaan kun pois näkyvistä
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
