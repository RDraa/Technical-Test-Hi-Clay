using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStat : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public GameObject healthUI1;
    public GameObject healthUI2;
    public GameObject healthUI3;
    public float health;
    public float maxHealth;

    [SerializeField] private AudioClip takeDamageAudioClip;
    private Animator hitBubbleAnim;
    public bool hitAt2 = false;
    public bool hitAt1 = false;
    public bool hitAt0 = false;

    void Start()
    {
        hitBubbleAnim = GetComponent<Animator>();
        maxHealth = health;
    }

    void Update()
    {
        Debug.Log("Sisa darah player: " + health);

        if (health == 2 && !hitAt2)
        {
            AudioManager.Instance.PlaySound(takeDamageAudioClip);
            hitBubbleAnim.SetTrigger("isHit");
            healthUI1.SetActive(false);
            hitAt2 = true;
        }

        if (health == 1 && !hitAt1)
        {
            AudioManager.Instance.PlaySound(takeDamageAudioClip);
            hitBubbleAnim.SetTrigger("isHit");
            healthUI2.SetActive(false);
            hitAt1 = true;
        }

        if (health <= 0 && !hitAt0)
        {
            AudioManager.Instance.PlaySound(takeDamageAudioClip);
            hitBubbleAnim.SetTrigger("isHit");
            Debug.Log("Bubble Dead");
            healthUI3.SetActive(false);
            hitAt0 = true;
            gameManagerScript.GameOver1();
        }
    }
}
