using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float waitTime;
    
    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.transform.position,
            bulletSpawnPoint.transform.rotation * Quaternion.Euler(90f, 0f, 0f));
    }
}
