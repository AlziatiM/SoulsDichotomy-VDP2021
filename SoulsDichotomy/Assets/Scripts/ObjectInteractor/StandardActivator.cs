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

    public void Interact()
    {   
        Switch();
        amIActive = !amIActive;
        foreach (IReact r in reactScripts)
        {
            r.React();
        }
    }

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
    }

}