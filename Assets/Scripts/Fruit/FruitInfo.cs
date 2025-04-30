using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitInfo : MonoBehaviour
{
    public int fruitIndex = 0;
    public int pointWhenAnnihilated = 1;
    public float fruitMass = 1f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.mass = fruitMass;
    }
}
