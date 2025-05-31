using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip popAudioClip;
    private bool isDead = false;
    private float flySpeed = 2f;
    private GameObject currentBubble;

    public GameObject[] bubbles;
    public GameObject deadAnim;
    public int health = 100;


    void Start()
    {
        if (bubbles.Length > 0 && bubbles[0] != null)
        {
            currentBubble = Instantiate(bubbles[0], transform.position, Quaternion.identity);
            currentBubble.transform.parent = transform;
        }
    }

    void Update()
    {
        if (isDead)
        {
            transform.position += Vector3.up * flySpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        Debug.Log("Health Enemy: " + health);

        if (health == 150)
        {
            ReplaceBubble(1);
        }
        else if (health == 125)
        {
            ReplaceBubble(2);
        }
        else if (health == 100)
        {
            ReplaceBubble(3);
        }
        else if (health == 75)
        {
            ReplaceBubble(4);
        }
        else if (health == 50)
        {
            ReplaceBubble(5);
        }
        else if (health == 25)
        {
            ReplaceBubble(6);
        }
        else if (health <= 0)
        {
            ReplaceBubble(7);
            StartCoroutine(FlyAndDestroy());
        }
    }

    void ReplaceBubble(int index)
    {
        if (index >= 0 && index < bubbles.Length && bubbles[index] != null)
        {
            if (currentBubble != null)
            {
                Destroy(currentBubble);
            }

            currentBubble = Instantiate(bubbles[index], transform.position, Quaternion.identity);
            currentBubble.transform.parent = transform;
        }
    }

    IEnumerator FlyAndDestroy()
    {
        isDead = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        yield return new WaitForSeconds(3f);

        if (currentBubble != null)
        {
            Destroy(currentBubble);
        }

        Destroy(gameObject);
        AudioManager.Instance.PlaySound(popAudioClip);
        GameObject diedVFX = Instantiate(deadAnim, transform.position, transform.rotation);
        Destroy(diedVFX, 1f);
    }

}
