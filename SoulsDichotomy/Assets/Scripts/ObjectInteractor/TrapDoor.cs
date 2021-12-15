using System;
using Assets.HeroEditor4D.Common.CommonScripts;
using TMPro.Examples;
using UnityEngine;

namespace ObjectInteractor
{
    public class TrapDoor : MonoBehaviour
    {
        [SerializeField] private bool hasTimer;
        private Timer timer;
        
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider;
        
        private void Start()
        {
            timer = gameObject.GetComponent<Timer>();
            boxCollider = gameObject.GetComponent<BoxCollider2D>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        
        
        private void OnValidate()
        {
            timer = gameObject.GetComponent<Timer>();
            if ( hasTimer && timer.GetTime() <= 0)
            {
                Debug.LogWarning("You are using a timer on " + gameObject.name + " but has an invalid time to count!");
            }
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ( collision.CompareTag("Player"))
            {
                    disappearTrapDoor();
                    reappearTrapDoor();
            }
        }

        private void disappearTrapDoor()
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;

        }
        
        private void reappearTrapDoor()
        
        {
            if (!hasTimer)
            {
                Destroy(this.gameObject);
            }
            else
            {
                
                timer.timeExpire += Respawn;
                timer.StartTimer();
            }
        }

        private void Respawn()
        {
            if (this != null)
            {
                spriteRenderer.enabled = true;
                boxCollider.enabled = true;
            }
        }
    }
}