using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : PickUp
{
    [SerializeField] private int amountHeal;
    public override void Apply(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          collision.GetComponent<PlayerInput>().Heal(amountHeal);
                
        }
    }
}