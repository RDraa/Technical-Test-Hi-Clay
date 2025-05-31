using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private AudioClip enemyShootAudioClip;
    private bool isAttacking = false;
    private Animator enemyAnimator;
    private Vector3 originalScale;
    private GameObject bubble;
    private float timer;

    public GameObject bulletEnemy;
    public Transform bulletPos;
    public float attackInterval = 5f;
    public float bubbleDetectionRadius = 3f;



    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
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

            if (!isAttacking && timer >= attackInterval)
            {
                timer = 0f;
                StartCoroutine(AttackDelay());
            }
        }
        else
        {
            timer = 0f;
        }
    }

    void Shoot()
    {
        AudioManager.Instance.PlaySound(enemyShootAudioClip);
        Instantiate(bulletEnemy, bulletPos.position, Quaternion.identity);
    }
    
    IEnumerator AttackDelay()
    {
        isAttacking = true;
        enemyAnimator.Play("Attack");

        yield return new WaitForSeconds(0.5f);
        Shoot();

        yield return new WaitForSeconds(1f);
        enemyAnimator.Play("Idle");

        isAttacking = false;
    }
}
