using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public BulletController bullet;
    
    
    public float bulletSpeed;
    private float lastTimeShot = 0;
    private float firingSpeed = 0.4f;

    public Transform firePoint;

    [SerializeField] AudioClip shootSound;

    public void Shoot()
    {
        if (shootSound)
        {
            AudioHelper.PlayerClip2D(shootSound, 0.1f);
        }
        if (lastTimeShot + firingSpeed <= Time.time)
        {
            lastTimeShot = Time.time;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            Destroy(newBullet.gameObject, 3);
            newBullet.bulletSpeed = bulletSpeed;
        }
    }
}
