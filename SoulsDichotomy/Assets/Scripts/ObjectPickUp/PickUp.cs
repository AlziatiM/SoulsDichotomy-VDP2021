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
    [Header("Prefab to instantiate when picked")]
    [SerializeField] GameObject iconPickUp;

    [Header("Who can pick up?")]
    [SerializeField] private bool canPlayerPick;
    [SerializeField] private bool canSoulPick;

    [Header("Who will affect?")]
    [SerializeField] private bool affectPlayer;
    [SerializeField] private bool affectSoul;

    [Header("Timer attributess")]
    [SerializeField] private bool hasTimer;
    [SerializeField] private Timer timer;
    [SerializeField] private bool canRespawn;

    protected GameObject player;
    protected GameObject soul;

    private void OnValidate()
    {
        timer = gameObject.GetComponent<Timer>();
        if ( hasTimer && timer.GetTime() <= 0)
        {
            Debug.LogWarning("You are using a timer on " + gameObject.name + " but has an invalid time to count!");
        }
        if(hasTimer && iconPickUp == null)
        {
            Debug.LogWarning("You can't have a pick up based over time witout a prefab to instantiate!");
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
        if(hasTimer)
            UIManager.instance.NewPickUp(iconPickUp, timer.GetTime());
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
            RemoveAffect();
            DisableVisibilityAndInteraction();
            if (canRespawn)
            {
                timer.timeExpire += Respawn;
            }
            else
            {
                timer.timeExpire += Destroy;
            }
            
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

    private void Respawn()
    {
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
