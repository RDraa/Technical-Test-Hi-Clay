using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    // public GameObject death;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die(); ;
        }
    }

    void Die()
    {
        // Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("Death Enemy");
    }
}
