using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public abstract class PickUp : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    [Header("Who can pick up?")]
    [SerializeField] private bool canPlayerPick;
    [SerializeField] private bool canSoulPick;

    [Header("Timer attributess")]
    [SerializeField] private bool hasTimer;
    [SerializeField] private Timer timer;

    protected GameObject player;
    protected GameObject soul;

    private void OnValidate()
    {
        timer = gameObject.GetComponent<Timer>();
        if ( hasTimer && timer.GetTime() <= 0)
        {
            Debug.LogWarning("You are using a timer on " + gameObject.name + " but has an invalid time to count!");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (canPlayerPick && collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            ApplyPlayer();
            ManageEndPowerUp(true);
        }
            
        if(canSoulPick && collision.CompareTag("Soul"))
        {
            soul = collision.gameObject;
            ApplySoul();
            ManageEndPowerUp(false);
        }
    }

    public void ManageEndPowerUp(bool fromPlayer)
    {
        if (!hasTimer)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (fromPlayer)
            {
                timer.timeExpire += RemovePlayer;
            }
            else
            {
                timer.timeExpire += RemoveSoul;
            }
            timer.StartTimer();
        }
    }

    public abstract void ApplyPlayer();
    public abstract void ApplySoul();
    public abstract void RemovePlayer();
    public abstract void RemoveSoul();
}
