using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject collisionParticle;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            SpawnEffect();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.TakeDamage(1);
        }
    }

    public void SpawnEffect()
    {
        GameObject particle = Instantiate(collisionParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        particle.transform.parent = null;
        particle.GetComponent<ParticleSystem>().Play();
    }
}
