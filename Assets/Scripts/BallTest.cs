using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{
    public static BallTest instance;
    public float atisGucu = 10f;
    public Rigidbody topRigidbody;
    public bool atisYapildi = false;
    public int damageCount;

    
    public GameObject collisionParticle;
    public GameObject explosionParticle;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        atisYapildi = true;
        topRigidbody.isKinematic = false;
        topRigidbody.AddForce(transform.forward * atisGucu, ForceMode.Impulse);
        if (ShipTest.instance != null)
        {
           ShipTest.instance.ShootSound();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            SpawnEffect();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
            Destroy(gameObject, 1f);
            atisYapildi = true;
            topRigidbody.isKinematic = true;
            CancelInvoke("ShotMissed");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageCount);
            }
            ShipTest.instance.HitSound();
            ExplosionEffect();
            Destroy(gameObject);
        }
    }
    public void SpawnEffect()
    {
        GameObject particle = Instantiate(collisionParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        particle.transform.parent = null;
        particle.GetComponent<ParticleSystem>().Play();
    }
    public void ExplosionEffect()
    {
        GameObject particle = Instantiate(explosionParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        particle.transform.parent = null;
        particle.GetComponent<ParticleSystem>().Play();
    }
}