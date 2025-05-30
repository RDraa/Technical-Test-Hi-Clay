using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAditional : MonoBehaviour
{
    private Vector3 originalScale;
    private GameObject bubble;
    private float timer;

    public float bubbleDetectionRadius = 3f;



    void Start()
    {
        bubble = GameObject.FindGameObjectWithTag("Bubble");
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (bubble == null) return;

        timer += Time.deltaTime;
        BubbleDistance();
    }

    void RotateEnemy()
    {
        if (bubble.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }

    void BubbleDistance()
    {
        float distance = Vector2.Distance(transform.position, bubble.transform.position);
        // Debug.Log("Jarak player dan enemy: " + distance);

        if (distance < bubbleDetectionRadius)
        {
            RotateEnemy();
        }
        else
        {
            timer = 0f;
        }
    }
}
