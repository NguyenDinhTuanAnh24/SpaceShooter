using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth health; // Tham chiếu đến máu của chính mình [cite: 478]
    public int damage;         // Sát thương gây ra khi đâm [cite: 479]

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem có đâm trúng Player không
        var playerHealth = collision.GetComponent<PlayerHealth>();
        
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Trừ máu Player [cite: 519]
            health.TakeDamage(1000);         // Tự kết liễu bản thân (trừ 1000 máu) [cite: 520]
        }
    }
}