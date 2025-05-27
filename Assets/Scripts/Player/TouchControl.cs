using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public bool isDown = false;
    public GameObject followingObject;
    public ThrowFruitController throwFruitController;
    public PlayerController playerController;
    public float moveSpeed = 10f; // 0 = instant snap, higher = smoother follow
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    public void PointerDown()
    {
        isDown = true;
    }
    public void PointerUp()
    {
        if (isDown)
        {
            throwFruitController.DropFruit();
        }

        isDown = false;
    }
    void Update()
    {
        if (isDown && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get first touch

            // Convert touch position to world coordinates
            Vector3 touchPos = mainCamera.ScreenToWorldPoint(touch.position);
            touchPos.y = followingObject.transform.position.y; // Keep original Y
            touchPos.z = followingObject.transform.position.z; // Keep original Z

            if (moveSpeed <= 0f)
            {
                followingObject.transform.position = touchPos; // Instant move
            }
            else
            {
                followingObject.transform.position = Vector3.Lerp(followingObject.transform.position, touchPos, moveSpeed * Time.deltaTime); // Smooth move
            }
            
            followingObject.transform.position = playerController.ClampPos();
        }
    }
}
