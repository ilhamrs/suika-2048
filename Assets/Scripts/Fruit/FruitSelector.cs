using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FruitSelector : MonoBehaviour
{
    public static FruitSelector Instance;

    public GameObject[] Fruits;
    public GameObject[] NoPhysicsFruits;
    public int highestStartingIndex = 3;

    [SerializeField] private Image nextFruitImage;
    [SerializeField] private Sprite[] fruitSprites;

    public GameObject NextFruit{ get; private set; }

    void Awake()
    {
        Instance = this;
    }
    public GameObject PickRandomFruitForThrow(){
        int randIndex = UnityEngine.Random.Range(0, highestStartingIndex + 1);

        if(randIndex < NoPhysicsFruits.Length)
        {
            GameObject randFruit = NoPhysicsFruits[randIndex];
            PickNextFruit();
            return randFruit;
        }

        return null;
    }
    public void PickNextFruit(){
        int randIndex = UnityEngine.Random.Range(0, highestStartingIndex + 1);

        if(randIndex < Fruits.Length){
            NextFruit = NoPhysicsFruits[randIndex];
            nextFruitImage.sprite = fruitSprites[randIndex];
        }
    }
}
