using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab; // Biến này được chuyển từ EnemyHealth sang đây
    public int defaultHealthPoint;     // Điểm máu mặc định (VD: 3) [cite: 228]
    private int healthPoint;

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
            Die(); // Hết máu thì gọi hàm chết [cite: 235]
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
        
        Destroy(gameObject); // Xóa đối tượng [cite: 220]
    }
}