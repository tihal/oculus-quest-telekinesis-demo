using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float fireRate;

    public Transform leftHand;
    
    public Transform rightHand;

    private float leftFire;

    private float rightFire;

    [SerializeField]
    private GameObject Bullet;


    private void FixedUpdate()
    {
        float triggerPullRight = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        float triggerPullLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        triggerSpellLeft(triggerPullLeft, leftHand);
        triggerSpellRight(triggerPullRight, rightHand);
    }

    void triggerSpellLeft (float triggerPullLeft, Transform leftHand)
    {
        while (triggerPullLeft > 0.9 && Time.time > leftFire)
        {
            leftFire = Time.time + fireRate;
            Instantiate(Bullet, leftHand.position, leftHand.rotation);
            break;
        }
    }

    void triggerSpellRight(float triggerPullRight, Transform rightHand)
    {
        while (triggerPullRight > 0.9 && Time.time > rightFire)
        {
            rightFire = Time.time + fireRate;
            Instantiate(Bullet, rightHand.position, rightHand.rotation);
            break;
        }
    }
}
