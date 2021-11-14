using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] protected bool CanDamagePlayer;
    [SerializeField] protected bool CanDamageSoul;
    public int damage;
    public bool damageOverTime;
    public float timeBetwDmg = 0.5f;

    private void OnValidate()
    {
        damage = Mathf.Clamp(damage, 0, 100);

        if (damageOverTime)
        {
            timeBetwDmg = Mathf.Clamp(timeBetwDmg, 0.01f, float.MaxValue);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hit = collision.GetComponent<IHittable>();
        if (hit != null)
        {
            if (CanDamagePlayer == true && collision.CompareTag("Player"))
            {
                ApplyDamage(hit);
            }

            if (CanDamageSoul == true && collision.CompareTag("Soul"))
            {
                ApplyDamage(hit);
            }
        }
    }

    public void ApplyDamage(IHittable hit)
    {
        if (damageOverTime)
            {
                IEnumerator myFunc = ApplyHit(hit);
                StartCoroutine(myFunc);
            }
        else
        {
            hit.Hit(damage);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        IHittable hit = collision.GetComponent<IHittable>();
        if (hit != null)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator ApplyHit(IHittable hit)
    {
        while (true)
        {
            hit.Hit(damage);
            yield return new WaitForSeconds(timeBetwDmg);
        }
    }
}
