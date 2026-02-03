using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float flySpeed = 2f; // Tốc độ bay

    void Update()
    {
        // Lệnh cho kẻ địch bay xuống dưới liên tục
        transform.Translate(Vector2.down * flySpeed * Time.deltaTime);
    }
}