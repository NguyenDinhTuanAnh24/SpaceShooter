using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Renderer bgRenderer;
    public float speed;

    void Update() => bgRenderer.material.mainTextureOffset = new Vector2(0, Time.time * speed);
}