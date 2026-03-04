using UnityEngine;
using System.Collections; // Cần thiết nếu chưa có

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint; // Điểm máu mặc định (VD: 3)
    private int healthPoint;

    // THÊM: Sự kiện được gọi khi đối tượng chết
    public System.Action onDead; //

    private void Start()
    {
        healthPoint = defaultHealthPoint;
    }

    // Hàm nhận sát thương
    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    // Hàm ảo (virtual) để lớp con có thể ghi đè
    protected virtual void Die()
    {
        // Tạo hiệu ứng nổ
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1f);
        }

        Destroy(gameObject); 

        // GỌI: Kích hoạt sự kiện onDead
        onDead?.Invoke(); //
    }
}