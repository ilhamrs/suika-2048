using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineController : MonoBehaviour
{
    [SerializeField] private Transform fruitThrowTransform;
    [SerializeField] private Transform bottomTransform;

    private LineRenderer lineRenderer;

    private float topPos;
    private float bottomPos;
    private float x;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        x = fruitThrowTransform.position.x;
        topPos = fruitThrowTransform.position.y;
        bottomPos = bottomTransform.position.y;

        lineRenderer.SetPosition(0, new Vector3(x, topPos));
        lineRenderer.SetPosition(1, new Vector3(x, bottomPos));
    }

    void OnValidate()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        x = fruitThrowTransform.position.x;
        topPos = fruitThrowTransform.position.y;
        bottomPos = bottomTransform.position.y;

        lineRenderer.SetPosition(0, new Vector3(x, topPos));
        lineRenderer.SetPosition(1, new Vector3(x, bottomPos));
    }
}
