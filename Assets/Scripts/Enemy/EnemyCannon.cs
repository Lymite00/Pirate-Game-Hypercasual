using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    public float fireRate = 3.0f;
    public float nextFire = 0.0f;
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float projectileSpeed = 10.0f;
    public float projectileLifetime = 5.0f;

    public AudioSource aSource;
    public AudioClip shootSound;
    void Update()
    {
        nextFire += Time.deltaTime;
        if (nextFire > fireRate) {
            nextFire = 0.0f;
            Fire();
        }
    }
    public void ShootSound()
    {
        aSource.clip = shootSound;
        aSource.Play();
    }
    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        
        ShootSound();
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        
        Destroy(projectile, projectileLifetime);
    }
}
