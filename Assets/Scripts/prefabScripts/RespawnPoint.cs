using UnityEngine;
using UnityEngine.AI;

public class RespawnPoint : MonoBehaviour
{


    public GameObject EnemyPrefab;


    // Update is called once per frame
    void Update()
    { 
        if (ShouldSpawn())
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy ()
    {
        Vector3 RandomSpawn = new Vector3(this.transform.position.x + Random.Range(-50, 50), this.transform.position.y, this.transform.position.z + Random.Range(-10, 10));
        GameObject clone;
        clone = Instantiate(EnemyPrefab, RandomSpawn, Quaternion.identity);

        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, -Vector3.up, out hit))
        {
            clone.transform.position = new Vector3(clone.transform.position.x, hit.point.y + 5, clone.transform.position.z);
        }

        
    }

    private bool ShouldSpawn()
    {
        return OVRInput.GetDown(OVRInput.Button.One);
    }
}
