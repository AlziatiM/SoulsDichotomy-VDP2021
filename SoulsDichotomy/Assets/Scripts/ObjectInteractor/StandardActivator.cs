using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StandardActivator : MonoBehaviour, IInteract
{
    [Header("Look")]
    [SerializeField] private Sprite nonActiveSprite;
    [SerializeField] private Sprite activeSprite;

    [Header("ActionToDo")]
    [SerializeField]
    private GameObject[] objHasToReac;
    private List<IReact> reactScripts = new List<IReact>();

    [Header("StartInfo")]
    [SerializeField] private bool doIStartActive;

    private void OnValidate()
    {
        if (objHasToReac != null)
        {
            foreach (GameObject go in objHasToReac)
            {
                IReact reactScript = go.GetComponent<IReact>();
                if (reactScript == null)
                {
                    Debug.LogError("No react foud on objHasToReac in: " + go.name);
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

    private bool amIActive;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        amIActive = doIStartActive;
    }

    public void Interact()
    {
        amIActive = !amIActive;
        foreach (IReact r in reactScripts)
        {
            r.React();
        }
    }

}