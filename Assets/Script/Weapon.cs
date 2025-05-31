using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform gunPoint;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulllets;
    [SerializeField] private GameObject shootingVFX;
    [SerializeField] private AudioClip shootAudioClip;
    public static bool isGamePaused = false;

    void Update()
    {
        if (GameManagerScript.isGamePaused) return;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("Klik kiri berhasil");
        }
    }

    void Shoot()
    {
        AudioManager.Instance.PlaySound(shootAudioClip);
        GameObject shootingEffect = Instantiate(shootingVFX, shootingPoint.position, shootingPoint.rotation);
        Destroy(shootingEffect, 0.5f);
        Instantiate(bulllets, gunPoint.position, gunPoint.rotation);
    }
}
