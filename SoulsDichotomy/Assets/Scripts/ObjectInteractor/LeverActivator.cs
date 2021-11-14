using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivator : StandardActivator
{
    [Header("Lever attributes - from open to close")]
    [SerializeField] private Sprite[] levelAnimation;
    [SerializeField] private float timeFrame;
    public override void Switch()
    {
        if (amIActive)
        {
            StartCoroutine("OpenLever");
        }
        else
        {
            StartCoroutine("CloseLever");
        }
    }

    private IEnumerator OpenLever()
    {
        
        for (int i = 0; i < levelAnimation.Length; i++)
        {
            spriteRenderer.sprite = levelAnimation[i];
            yield return new WaitForSeconds(timeFrame);
        }
        spriteRenderer.sprite = nonActiveSprite;
    }

    private IEnumerator CloseLever()
    {
        for (int i = levelAnimation.Length - 1; i >= 0; i--)
        {
            spriteRenderer.sprite = levelAnimation[i];
            yield return new WaitForSeconds(timeFrame);
        }
        spriteRenderer.sprite = activeSprite;
    }
}
