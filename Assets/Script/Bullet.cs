using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBullet = 20f;
    public int damage = 25;
    public Rigidbody2D rb;
    public GameObject bubblePop;

    void Start()
    {
        rb.velocity = transform.right * speedBullet;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        GameObject popVFX = Instantiate(bubblePop, transform.position, transform.rotation);
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
        Destroy(popVFX, 0.5f);
    }
}
