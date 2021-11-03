using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IReact
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public bool isClosed=true;
    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void React()
    {
        isClosed = !isClosed;
        //spriteRenderer.color = new Color(Random.Range(0, 255)/255f, Random.Range(0, 255)/255f, Random.Range(0, 255)/255f);
        spriteRenderer.enabled = isClosed;
        boxCollider.enabled = isClosed;
    }
}
