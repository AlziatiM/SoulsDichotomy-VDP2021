using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class ButtonActivator : StandardActivator
{
    private Timer timer;

    public void Awake()
    {
        base.SetUpActivator();
        timer = this.gameObject.GetComponent<Timer>();
        timer.timeExpire += Interact;
    }

    public override void Switch()
    {
        if(amIActive)
        {
            spriteRenderer.sprite = nonActiveSprite;
        }
        else
        {
            spriteRenderer.sprite = activeSprite;
            timer.StartTimer();
        }
        ReactAll();
    }

    
}
