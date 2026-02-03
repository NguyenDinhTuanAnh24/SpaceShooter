using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Kéo Prefab viên đạn của Enemy vào đây
    public Transform firePoint;     // Vị trí bắn (thường là đầu máy bay)
    public float fireRate = 2f;     // Bắn mỗi 2 giây
    private float nextFireTime = 0f;

    void Update()
    {
        // Kiểm tra thời gian để bắn
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}