using Assets.HeroEditor4D.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour
{

    private GameObject _player;
    public Vector3 offset;
    public Character4D Character;
    public bool InitDirection;
    public int MovementSpeed;
    public KeyCode activeInputSoul; //dovrebbe essere salvato nel gm
    private bool moveFromInput;
    public bool _moving;

    public void Start()
    {
        Character.AnimationManager.SetState(CharacterState.Idle);
        moveFromInput = false;
        if (InitDirection)
        {
            Character.SetDirection(Vector2.right);
        }

        _player = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        if (Input.GetKey(activeInputSoul))
        {
            moveFromInput = !moveFromInput;
            
        }
        if (moveFromInput)
        {
            SetDirection();
            MoveFromInput();
        }
        else
        {
            Vector2 distance = _player.transform.position - transform.position;
            Vector2 direction = (_player.transform.position - transform.position - offset).normalized;

            if (_moving == true)
            {
                if (Mathf.Abs(direction.x) < 0.2f)
                {
                    Move(Vector2.zero);
                }
                else
                {
                    Move(direction);
                }

            }
            else
            {
                if (Mathf.Abs(distance.x) > 5f)
                {
                    Move(direction);
                }
            }

            
        }
    }

    

    private void SetDirection()
    {
        Vector2 direction;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else return;

        Character.SetDirection(direction);
    }

    private void MoveFromInput()
    {
        if (MovementSpeed == 0) return;

        var direction = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        Move(direction);
    }

    private void Move(Vector2 direction)
    {

        if (direction == Vector2.zero)
        {
            if (_moving)
            {
                Character.AnimationManager.SetState(CharacterState.Idle);
                _moving = false;
            }
        }
        else
        {
            Character.AnimationManager.SetState(CharacterState.Run);
            Character.transform.position += (Vector3)direction.normalized * MovementSpeed * Time.deltaTime;
            _moving = true;
        }
    }
}
