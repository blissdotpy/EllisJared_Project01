using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}");
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null || other.GetComponent<PlayerManager>() != null) return;
        damageable.TakeDamage(10);
        Destroy(gameObject);
    }
}
