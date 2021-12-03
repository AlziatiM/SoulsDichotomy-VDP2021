using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class StandardActivator : MonoBehaviour, IInteract
{
    [Header("Look")]
    [SerializeField] protected Sprite nonActiveSprite;
    [SerializeField] protected Sprite activeSprite;

    [Header("Who can interact with:")]
    [SerializeField] protected bool canPlayerInteract;
    [SerializeField] protected bool canSoulInteract;


    [Header("ActionToDo")]
    [SerializeField]
    private GameObject[] objHasToReac;
    private List<IReact> reactScripts = new List<IReact>();

    [Header("StartInfo")]
    [SerializeField] protected bool amIActive;

    private void OnValidate()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        if (objHasToReac != null)
        {
            foreach (GameObject go in objHasToReac)
            {
                IReact reactScript = go.GetComponent<IReact>();
                if (reactScript == null)
                {
                    objHasToReac = null;
                    reactScripts.Clear();
                }
                else
                {
                    reactScripts.Add(reactScript);
                }
            }

        }
    }

    protected SpriteRenderer spriteRenderer;
    private void Awake()
    {
        SetUpActivator();
    }

    private void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        foreach (GameObject go in objHasToReac)
        {
            IReact reactScript = go.GetComponent<IReact>();
            reactScripts.Add(reactScript);
            
        }
    }

    protected void SetUpActivator()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        if (amIActive)
        {
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = nonActiveSprite;
        }
    }

    private void StartInteraction()
    {
        Switch();
        amIActive = !amIActive;
    }

    protected void ReactAll()
    {
        Debug.Log("sono nel debug");
        foreach (IReact r in reactScripts)
        {
            Debug.Log("Eccomi dentro al for");
            r.React();
        }
    }

    /// <summary>
    /// the switch have to manage also the ManageAll when needed
    /// </summary>
    public virtual void Switch()
    {
        if(amIActive)
        {
            spriteRenderer.sprite = nonActiveSprite;
        }
        else
        {
            spriteRenderer.sprite = activeSprite;
        }
        ReactAll();
    }

    public void Interact()
    {
        StartInteraction();
    }

    public bool CanPlayerInteract()
    {
        return canPlayerInteract;
    }

    public bool CanSoulInteract()
    {
        return canSoulInteract;
    }
}