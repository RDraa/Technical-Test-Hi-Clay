using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject bubble;
    private Rigidbody2D rb;

    public float force;
    public float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bubble = GameObject.FindGameObjectWithTag("Bubble");

        Vector3 direction = bubble.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            other.gameObject.GetComponent<BubbleStat>().health -= 1;
            Destroy(gameObject);
        }
    }
}
