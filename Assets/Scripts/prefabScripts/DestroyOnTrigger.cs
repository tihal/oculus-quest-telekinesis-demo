
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public bool DestroySelfOnCollision = false;
    public GameObject cubeShattered;
    private Transform garbageDump;

    private void Start()
    {
        //garbageDump = FindObjectOfType<GameManagerScript>().garbageHellfire;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(cubeShattered, other.transform.position, other.transform.rotation);
            GetComponent<Rigidbody>().AddExplosionForce(Random.Range(100, 500), transform.position, 5);
            GameObject enemyGameObject = other.gameObject;
            enemyGameObject.transform.position = garbageDump.position;


        }
        if (DestroySelfOnCollision == true)
        {
            Destroy(gameObject);
        }
    }
}
