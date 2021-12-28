using System;
using System.Collections;

using TMPro.Examples;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TrapDoor: Door
{
    [Header("Timer hav the time to re-open it")]
    private Timer timer;

    private bool playerOnTop;
    public override void Awake()
    {
        timer = gameObject.GetComponent<Timer>();
        playerOnTop = false;
        base.Awake();
    }

    public override void React()
    {
        if (playerOnTop)
        {
            base.React();
            playerOnTop = false;
        }
        
        
    }

    protected override void DoAfterOpen()
    {
        base.DoAfterOpen();
        timer.timeExpire += React;
        timer.StartTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 collisionPoint = collision.ClosestPoint(transform.position);
            Vector3 playerCenter = collision.bounds.center;
            
            bool isBelowPlayer = collisionPoint.y < playerCenter.y;

            if (isBelowPlayer)
            {
                playerOnTop = true;

            }
        }
    }
}