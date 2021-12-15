using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardReactor : MonoBehaviour
{

    [Header("Sprites - from close to open")]

    [SerializeField] private Sprite[] aminationSprite;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    [Header("Initial State")]
    public bool isClosed = true;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
