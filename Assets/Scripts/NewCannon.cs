using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCannon : MonoBehaviour
{
    public static NewCannon instance;
    public GameObject cannonBall;
    public Transform spawnPoint;
    
    public GameObject cannonParticle;

    public bool isSpawn;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }

    public void Spawn()
    {
        if (!isSpawn&& Collectables.instance.canShoot)
        {
            isSpawn = true;
            StartCoroutine(SpawnAndShoot());
        }
    }
    public void SpawnParticle()
    {
        GameObject particle = Instantiate(cannonParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        particle.transform.parent = transform.parent;
        particle.GetComponent<ParticleSystem>().Play();
    }

    private IEnumerator SpawnAndShoot()
    {
        Collectables.instance.ammoCount -= 1;
        // Top mermisini oluşturun
        GameObject projectile = Instantiate(cannonBall, spawnPoint.position, spawnPoint.rotation);

        // Top mermisine fiziksel bir kuvvet uygulayın (örneğin, fırlatın)
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(transform.forward * 10f, ForceMode.Impulse);

        BallTest.instance.Shoot();
        SpawnParticle();

        yield return new WaitForSeconds(0.3f);

        isSpawn = false;
    }
}
