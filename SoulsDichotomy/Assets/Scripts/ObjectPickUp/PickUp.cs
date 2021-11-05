using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    
    /*private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }*/
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Apply(collision);
        if (collision.CompareTag("Player") || collision.CompareTag("Soul"))
        {
            // spriteRenderer.enabled = false;
            // boxCollider.enabled = false;
            Destroy(this.gameObject);
            
        }
    }
    public abstract void Apply(Collider2D collision);
}
