using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform gunPoint;
    public GameObject bulllets; 

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("Klik kiri berhasil");
        }
    }

    void Shoot()
    {

        Instantiate(bulllets, gunPoint.position, gunPoint.rotation);
    }
}
