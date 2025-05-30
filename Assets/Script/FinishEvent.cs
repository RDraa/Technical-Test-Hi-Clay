using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvent : MonoBehaviour
{
    [SerializeField]private GameManagerScript gameFinish;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameFinish.GameFinish();
        }  
    }
}
