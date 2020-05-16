using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    public bool DestroySelfOnCollision = false;
    public GameObject cubeShattered;
    private Transform garbageDump;

    private void Start()
    {
        //garbageDump = FindObjectOfType<GameManagerScript>().garbageHellfire;
    }

    void OnCollisionEnter(Collision collision)
       {

           if (collision.gameObject.tag == "Enemy")
           {
            Instantiate(cubeShattered, collision.transform.position, collision.transform.rotation);
            GetComponent<Rigidbody>().AddExplosionForce(Random.Range(100, 500), transform.position, 5);
            GameObject enemyGameObject = collision.gameObject;
            enemyGameObject.transform.position = garbageDump.position;


           }
        if (DestroySelfOnCollision == true)
        {
            Destroy(gameObject);
        }
    }


}


