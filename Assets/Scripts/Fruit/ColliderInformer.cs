using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombinedIn {get; set;}

    private bool hasCollided;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!hasCollided && !WasCombinedIn){
            hasCollided = true;
            ThrowFruitController.Instance.CanThrow = true;
            ThrowFruitController.Instance.SpawnAFruit(FruitSelector.Instance.NextFruit);
            FruitSelector.Instance.PickNextFruit();
            Destroy(this);
        }
    }
}
