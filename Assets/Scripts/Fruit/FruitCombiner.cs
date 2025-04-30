using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCombiner : MonoBehaviour
{
    private int layerIndex;
    private FruitInfo info;
    void Awake()
    {
        info = GetComponent<FruitInfo>();
        layerIndex = gameObject.layer;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == layerIndex){
            FruitInfo i = collision.gameObject.GetComponent<FruitInfo>();
            if(i != null){
                if(i.fruitIndex == info.fruitIndex){
                    int thisID = gameObject.GetInstanceID();
                    int otherID = collision.gameObject.GetInstanceID();

                    if(thisID > otherID){
                        GameManager.Instance.IncreaseScore(info.pointWhenAnnihilated);
                        
                        if(info.fruitIndex == FruitSelector.Instance.Fruits.Length - 1){
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                        else{
                            Vector3 middlePos = (transform.position + collision.transform.position) / 2f;
                            GameObject go = Instantiate(SpawnCombinedFruit(info.fruitIndex), GameManager.Instance.transform);
                            go.transform.position = middlePos;

                            ColliderInformer informer = go.GetComponent<ColliderInformer>();
                            if(informer != null){
                                informer.WasCombinedIn = true;
                            }

                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

    private GameObject SpawnCombinedFruit(int index){
        GameObject go = FruitSelector.Instance.Fruits[index + 1];
        return go;
    }
}
