using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEffects : MonoBehaviour
{
    public GameObject meshRenderer;

    private Coroutine damageCoroutine;

    private void Start()
    {
        
    }

    public void TakeDamageEffect()
    {
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
        }

        damageCoroutine = StartCoroutine(DamageEffectCoroutine());
    }

    private IEnumerator DamageEffectCoroutine()
    {
        PlayerHealthController.instance.canDamage = false;
        meshRenderer.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        PlayerHealthController.instance.canDamage = true;
        meshRenderer.SetActive(true);
    }
}
