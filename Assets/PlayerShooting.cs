using UnityEngine;

namespace Tutorial
{
    public class PlayerShooting : MonoBehaviour
    {
        public GameObject bulletPrefabs;
        public float shootingInterval;
        public Vector3 bulletOffset;
        private float lastBulletTime;

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time - lastBulletTime > shootingInterval)
                {
                    ShootBullet();
                    lastBulletTime = Time.time;
                }
            }
        }

        private void ShootBullet()
        {
            var bullet = Instantiate(bulletPrefabs, transform.position + bulletOffset, transform.rotation);
        }
    }
}
