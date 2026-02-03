using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed;
    public int damage; // Sát thương của đạn 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem vật va chạm có phải là Enemy không
        var enemy = collision.GetComponent<EnemyHealth>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Gây sát thương [cite: 255]
        }
        
        Destroy(gameObject); // Xóa viên đạn ngay sau khi va chạm [cite: 257]
    }
}