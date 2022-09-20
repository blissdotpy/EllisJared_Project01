using UnityEditor.UIElements;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public BulletController bullet;
    
    
    public float bulletSpeed;
    private float lastTimeShot = 0;
    private float firingSpeed = 0.2f;

    public Transform firePoint;

    public void Shoot()
    {
        if (lastTimeShot + firingSpeed <= Time.time)
        {
            lastTimeShot = Time.time;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            Destroy(newBullet.gameObject, 3);
            newBullet.bulletSpeed = bulletSpeed;
        }
    }
}
