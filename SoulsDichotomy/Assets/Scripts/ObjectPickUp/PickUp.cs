using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class PickUp : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    [Header("Who can pick up?")]
    [SerializeField] private bool canPlayerPick;
    [SerializeField] private bool canSoulPick;

    [Header("Who will affect?")]
    [SerializeField] private bool affectPlayer;
    [SerializeField] private bool affectSoul;

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

    private void Awake()
    {
        timer = gameObject.GetComponent<Timer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (canPlayerPick && collision.CompareTag("Player"))
        {
            SetPlayerAndSoul();
            DispatchAffect();
            ManageEndPowerUp();
        }
            
        if(canSoulPick && collision.CompareTag("Soul"))
        {
            SetPlayerAndSoul();
            DispatchAffect();
            ManageEndPowerUp();
        }
    }

    public void SetPlayerAndSoul()
    {
        soul = GameObject.FindGameObjectWithTag("Soul");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void DispatchAffect()
    {
        if (affectPlayer)
        {
            ApplyPlayer();
        }
        if (affectSoul)
        {
            ApplySoul();
        }
    }

    private void RemoveAffect()
    {
        if (affectPlayer)
        {
            timer.timeExpire += RemovePlayer;
        }

        if(affectSoul)
        {
            timer.timeExpire += RemoveSoul;
        }
    }

    public void ManageEndPowerUp()
    {
        if (!hasTimer)
        {
            Destroy();
        }
        else
        {
            DisableVisibilityAndInteraction();
            RemoveAffect();
            timer.timeExpire += Destroy;
            timer.StartTimer();
        }
    }

    private void DisableVisibilityAndInteraction()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    public abstract void ApplyPlayer();
    public abstract void ApplySoul();
    public abstract void RemovePlayer();
    public abstract void RemoveSoul();

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
