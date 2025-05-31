using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private AudioClip enemyShootAudioClip;
    private Animator enemyAnimator;
    private Transform bubble;
    private int currentWaypointIndex = 0;
    private float timer;
    private bool isTrackingBubble = false;
    private bool isAttacking = false;
    private bool isWaiting = false;


    public GameObject bulletEnemy;
    public Transform bulletPos;
    public Transform[] waypoints;
    public float moveSpeed = 3f;
    public float waitTime = 1f;
    public float bubbleDetectionRadius = 3f;
    public float attackInterval = 5f;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        bubble = GameObject.FindGameObjectWithTag("Bubble")?.transform;

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (isWaiting || waypoints.Length == 0) return;
        if (bubble == null) return;

        float distance = Vector2.Distance(transform.position, bubble.position);

        if (distance < bubbleDetectionRadius)
        {
            isTrackingBubble = true;
            RotateToTarget(bubble.position);

            timer += Time.deltaTime;

            if (!isAttacking && timer >= attackInterval)
            {
                timer = 0f;
                StartCoroutine(AttackWait());
            }

            return;
        }

        else
        {
            isTrackingBubble = false;
            timer = 0f;
        }

        if (!isTrackingBubble)
        {
            MoveToPoint();
            RotateEnemy();
        }
    }

    void MoveToPoint()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[currentWaypointIndex].position,
            moveSpeed * Time.deltaTime
        );

        enemyAnimator.Play("Walk");

        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.01f)
        {
            enemyAnimator.Play("Idle");
            StartCoroutine(WaitAtWaypoint());
        }
    }

    void RotateEnemy()
    {
        if (waypoints[currentWaypointIndex].position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void RotateToTarget(Vector3 targetPosition)
    {
        if (targetPosition.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Shoot()
    {
        AudioManager.Instance.PlaySound(enemyShootAudioClip);
        Instantiate(bulletEnemy, bulletPos.position, Quaternion.identity);
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isWaiting = false;
    }

    IEnumerator AttackWait()
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
