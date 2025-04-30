using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private BoxCollider2D boundaries;
    [SerializeField] private Transform fruitThrowTransform;

    private Bounds bounds;

    private float leftBound;
    private float rightBound;

    private float startingLeftBound;
    private float startingRightBound;

    private float offset;

    void Awake()
    {
        bounds = boundaries.bounds; 

        offset = transform.position.x - fruitThrowTransform.position.x;

        leftBound = bounds.min.x + offset;
        rightBound = bounds.max.x + offset;

        startingLeftBound = leftBound;
        startingRightBound = rightBound;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position + new Vector3(UserInput.MoveInput.x * moveSpeed * Time.deltaTime, 0f, 0f);
        newPos.x = Mathf.Clamp(newPos.x, leftBound, rightBound);

        transform.position = newPos;
    }

    public void ChangeBoundary(float extraWidth){
        leftBound = startingLeftBound;
        rightBound = startingRightBound;

        leftBound += ThrowFruitController.Instance.Bounds.extents.x + extraWidth;
        rightBound -= ThrowFruitController.Instance.Bounds.extents.x + extraWidth;
    } 
}
