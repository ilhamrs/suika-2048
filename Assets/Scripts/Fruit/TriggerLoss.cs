using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoss : MonoBehaviour
{
    private float timer = 0f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Lose")){
            timer += Time.deltaTime;
            if(timer > GameManager.Instance.timeTillGameOver){
                GameManager.Instance.GameOver();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Lose")){
            timer = 0f;
        }
    }

}
