using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEvent : MonoBehaviour
{
    [SerializeField]private GameManagerScript gameOver;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameOver.GameOver();
        }
    }
}
