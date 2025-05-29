using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject bubble;
    public GameObject bulletEnemy;
    public Transform bulletPos;

    private float timer;

    void Start()
    {
        bubble = GameObject.FindGameObjectWithTag("Bubble");
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, bubble.transform.position);

        if (distance < 9)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletEnemy, bulletPos.position, Quaternion.identity);
    }
}
