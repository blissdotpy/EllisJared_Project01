using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public float maxDistance;
    
    private Rigidbody bulletRB;

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB.AddForce(transform.forward * bulletSpeed);
        
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
        {
            Destroy(gameObject);
        }
    }
}
