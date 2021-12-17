using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damage))]
public class DamageReact : MonoBehaviour, IReact
{
    [Header("From turn off to turn on")]
    [SerializeField] private Sprite[] aminationSprite;
    [SerializeField] private float timeAnimation = 0.5f;
    [Header("Initial State")]
    [SerializeField] private bool amIActive;
    
    private Damage myDamage;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myDamage = gameObject.GetComponent<Damage>();
    }

    private void Start()
    {
        if (amIActive)
        {
            spriteRenderer.sprite = aminationSprite[aminationSprite.Length - 1];
            boxCollider.enabled = true;
            myDamage.enabled = true;
        }
        else
        {
            spriteRenderer.sprite = aminationSprite[0];
            boxCollider.enabled = false;
            myDamage.enabled = false;
        }
    }

    public void React()
    {
        if (amIActive)
        {
            StartCoroutine("CloseDamage");
        }
        else
        {
            StartCoroutine("OpenDamage");
        }
        amIActive = !amIActive;
    }

    private IEnumerator OpenDamage()
    {
        boxCollider.enabled = true;
        myDamage.enabled = true;
        for (int i = 1; i < aminationSprite.Length; i++)
        {
            spriteRenderer.sprite = aminationSprite[i];
            yield return new WaitForSeconds(timeAnimation);
        }
    }

    private IEnumerator CloseDamege()
    {
        boxCollider.enabled = false;
        myDamage.enabled = false;
        for (int i = aminationSprite.Length - 2; i >= 0; i--)
        {
            spriteRenderer.sprite = aminationSprite[i];
            yield return new WaitForSeconds(timeAnimation);
        }
    }

}
