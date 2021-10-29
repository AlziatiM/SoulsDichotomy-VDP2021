
using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
 
[Serializable]
public class Health 
{
    public int maxHealth;
    
    public int currentHealth;
    
    public UnityEvent onHeal;
    public UnityEvent onDamage;
    public UnityEvent onDeath;

    void AddHp(int value)
    {
        currentHealth = math.min(maxHealth, currentHealth + value);
        onHeal.Invoke();
    }
    void SubtractHp(int value)
    {
        currentHealth -= value;
        onDamage.Invoke();
        if (currentHealth <= 0)
        {
            Die();
        } 
    }

    void Die()
    {
        onDeath.Invoke();
    }
    
    
}
