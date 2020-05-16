using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public bool isDead;
    public bool inCombat;
    public float wanderTime;
    public float movementSpeed;


    public int AttackDamageMin;
    public int AttackDamageMax;
    public float AttackCooldownTimeMain;
    public float AttackCooldownTime;

    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {

            if (Target == null)
            {
                SearchForTarget();


                if (wanderTime > 0)
                {
                    transform.Translate(Vector3.forward * movementSpeed);
                    wanderTime -= Time.deltaTime;
                }
                else
                {
                    wanderTime = Random.Range(3.0f, 10.0f);
                    Wander();
                }

            } else
            {
                FollowTarget();
            }

        }
    }

    void Wander ()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }


    void SearchForTarget ()
    {
        Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(center, 30);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].transform.tag == "Player")
            {
                Target = hitColliders[i].transform.gameObject;
            }
            i++;
        }
    }

    void FollowTarget()
    {
        Vector3 targetPosition = Target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);

        float distance = Vector3.Distance(Target.transform.position, this.transform.position);
        if (distance > 1.2)
        {
            transform.Translate(Vector3.forward * movementSpeed);
        } else
        {
            if (AttackCooldownTime > 0)
            {
                AttackCooldownTime -= Time.deltaTime;
            } else
            {
                AttackCooldownTime = AttackCooldownTimeMain;
                AttackTarget();
            }
        }
    }

    void AttackTarget()
    {
        //Target.transform.GetComponent<UserStats>().ReceiveDamage(Random.Range(AttackDamageMin, AttackDamageMax));
    }
}
