using UnityEngine;
public class PlayerHealth : Health // Kế thừa từ Health
{
    protected override void Die()
    {
        base.Die(); // Gọi hàm Die của cha để tạo nổ và xóa
        Debug.Log("Player died"); // Thông báo [cite: 195]
    }
}