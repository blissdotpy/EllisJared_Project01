using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeController : MonoBehaviour
{
    public GameObject enemyObject;

    private float objSize;

    public int objInRow = 5;

    private float objPivotDistance;

    private Vector3 objPivot;
    
    [Header("Explode Settings")]

    public float explosionForce = 50f;

    public float explosionRadius = 4f;

    public float explosionUpward = 0.4f;

    private void Awake()
    {
        objSize = transform.localScale.x / objInRow;
    }

    // Start is called before the first frame update
    void Start()
    {
        objPivotDistance = objSize * objInRow / 2;
        objPivot = new Vector3(objPivotDistance, objPivotDistance, objPivotDistance);
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ground")
        {
            Explode();
        }
    }

    public void Explode()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < objInRow; x++)
        {
            for (int y = 0; y < objInRow; y++)
            {
                for (int z = 0; z < objInRow; z++)
                {
                    DuplicateObject(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void DuplicateObject(int x, int y, int z)
    {
        GameObject enemy;
        enemy = Instantiate(enemyObject, new Vector3(x, y, z), Quaternion.identity);

        enemy.transform.position = transform.position + new Vector3(objSize * x, objSize * y, objSize * z) - objPivot;
        enemy.transform.localScale = new Vector3(objSize, objSize, objSize);

        // enemy.AddComponent<Rigidbody>();
        enemy.SetActive(true);
        enemy.GetComponent<Rigidbody>().mass = objSize;
    }
}
