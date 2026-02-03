using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;    // Tốc độ bay của đạn
    public int damage = 1;      // Sát thương gây ra

   void Update()
{
    // Thêm tham số Space.World để bắt buộc bay xuống đáy màn hình
    // Bất kể mũi đạn đang xoay hướng nào
    transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
}

    // Hàm xử lý va chạm
    private void OnTriggerEnter2D(Collider2D collision)
{
    // Dòng này rất quan trọng: Nó tìm component "PlayerHealth" trên vật va chạm
    var player = collision.GetComponent<PlayerHealth>(); 

    if (player != null)
    {
        player.TakeDamage(damage); // Gọi lệnh trừ máu
        Destroy(gameObject);       // Xóa viên đạn
    }
}

    // Tự hủy viên đạn sau 4 giây để tránh đầy bộ nhớ
    void Start()
    {
        Destroy(gameObject, 4f);
    }
}