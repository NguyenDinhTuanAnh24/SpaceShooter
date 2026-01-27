using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Biến chứa hiệu ứng nổ (sẽ dùng ở phần 6)
    public GameObject explosionPrefab;

    // Hàm này tự động chạy khi có vật thể (Trigger) chạm vào
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die(); // Gọi hàm chết
    }

    private void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1f); // Hủy vụ nổ sau 1 giây
        }
        Destroy(gameObject); // Xóa kẻ địch khỏi game ngay lập tức
    }
}