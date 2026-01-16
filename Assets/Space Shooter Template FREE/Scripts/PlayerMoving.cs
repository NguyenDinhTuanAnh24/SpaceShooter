using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines the borders of ‘Player’s’ movement. Depending on the chosen handling type, it moves the ‘Player’ together with the pointer.
/// </summary>

[System.Serializable]
public class Borders
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class PlayerMoving : MonoBehaviour {

    [Tooltip("offset from viewport borders for player's movement")]
    public Borders borders;
    Camera mainCamera;
    bool controlIsActive = true; 

    public static PlayerMoving instance; //unique instance of the script for easy access to the script

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();                //setting 'Player's' moving borders deending on Viewport's size
    }

    private void Update()
    {
        // 1. RETRIEVE MOUSE POSITION
        Debug.Log(Input.mousePosition);

        if (controlIsActive)
        {
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
            // 2. MOVE PLAYER TO MOUSE POSITION
            var worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            transform.position = worldPoint;
#endif

#if UNITY_IOS || UNITY_ANDROID
             if (Input.touchCount == 1) 
             {
                 Touch touch = Input.touches[0];
                 Vector3 touchPos = touch.position;
                 touchPos.z = 10f;
                 Vector3 touchWorldPoint = mainCamera.ScreenToWorldPoint(touchPos);
                 touchWorldPoint.z = 0;
                 transform.position = touchWorldPoint;
             }
#endif
            
            // Commenting out clamping to ensure it follows mouse 100% like the slide
            /*
            transform.position = new Vector3
                (
                Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
                Mathf.Clamp(transform.position.y, borders.minY, borders.maxY),
                0
                );
            */
        }
    }

    //setting 'Player's' movement borders according to Viewport size and defined offset
    void ResizeBorders() 
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}
