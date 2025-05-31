using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private AudioClip regenAudioClip;
    private Animator animator;
    private int itemRegen = 1;
    public BubbleStat bubbleStat;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (bubbleStat.health < 3)
            {
                StartCoroutine(PlayPopThenDestroy());
            }
            else
            {
                Debug.Log("Health Penuh!");
            }
        }
    }

    private IEnumerator PlayPopThenDestroy()
    {
        if (bubbleStat.health == 2)
        {
            AudioManager.Instance.PlaySound(regenAudioClip);
            bubbleStat.healthUI1.SetActive(true);
            bubbleStat.hitAt2 = false;
        }
        else if (bubbleStat.health == 1)
        {
            AudioManager.Instance.PlaySound(regenAudioClip);
            bubbleStat.healthUI2.SetActive(true);
            bubbleStat.hitAt1 = false;
        }

        bubbleStat.health += itemRegen;

        animator.Play("Pop");

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
        Debug.Log("Health Bubble: " + bubbleStat.health);
    }
}
