using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(speed * transform.forward);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(speed * transform.forward);
    }
}
