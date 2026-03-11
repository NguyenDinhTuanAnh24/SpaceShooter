using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform mask;
    public Health health; // Đổi 'Health' thành 'PlayerHealth' nếu script máu của bạn tên là PlayerHealth
    private float originalWidth;

    void Start()
    {
        originalWidth = mask.sizeDelta.x;
        UpdateHealthValue();
        health.onHealthChanged += UpdateHealthValue;
    }

    private void UpdateHealthValue()
    {
        // Nhớ đảm bảo biến máu hiện tại và máu tối đa trong script kia đang để public nhé
        float scale = (float)health.healthPoint / health.defaultHealthPoint; 
        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }
}