using UnityEngine;

// Thay đổi: Kế thừa từ 'Health' thay vì 'MonoBehaviour'
public class EnemyHealth : Health 
{
    // Ghi đè hàm Die của cha để thêm hành động riêng (nếu cần)
    protected override void Die()
    {
        base.Die(); // Gọi lại logic nổ và xóa object của lớp cha (Health)
        Debug.Log("Enemy died"); // In thông báo ra màn hình console [cite: 206]
    }
}