using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitController : MonoBehaviour
{
    public static ThrowFruitController Instance;

    public GameObject CurrentFruit { get; set; }
    [SerializeField] private Transform fruitTransform;
    [SerializeField] private Transform parentAfterThrow;
    [SerializeField] private FruitSelector selector;

    private PlayerController playerController;

    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    public Bounds Bounds { get; private set; }
    private const float EXTRA_WIDTH = .02f;
    public bool CanThrow { get; set; } = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();

        SpawnAFruit(selector.PickRandomFruitForThrow());
    }

    void Update()
    {
        if (UserInput.IsThrowPressed && CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentFruit.transform.rotation;

            GameObject go = Instantiate(FruitSelector.Instance.Fruits[index.index], CurrentFruit.transform.position, rot);
            go.transform.SetParent(parentAfterThrow);

            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }

    public void SpawnAFruit(GameObject f)
    {
        GameObject go = Instantiate(f, fruitTransform);
        CurrentFruit = go;
        circleCollider = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = circleCollider.bounds;

        playerController.ChangeBoundary(EXTRA_WIDTH);

    }

    public void DropFruit()
    {
        if (CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentFruit.transform.rotation;

            GameObject go = Instantiate(FruitSelector.Instance.Fruits[index.index], CurrentFruit.transform.position, rot);
            go.transform.SetParent(parentAfterThrow);

            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }
}
