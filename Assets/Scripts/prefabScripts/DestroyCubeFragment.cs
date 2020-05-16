using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubeFragment : MonoBehaviour
{

    public float cubeSpeed = 125f;

    float directionX;
    float directionY;

    void Start()
    {

        directionX = Random.Range(-8f, 8f);
        directionY = Random.Range(-4f, 4f);
        //Add explosion force
        GetComponent<Rigidbody>().AddForce(new Vector3(directionX, directionY).normalized * cubeSpeed);
        
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 5);
    }
}
