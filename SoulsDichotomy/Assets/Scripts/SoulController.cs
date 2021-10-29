using Assets.HeroEditor4D.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour
{
    //reference for player
    private GameObject _player;
    [Header("Chase player stats")]
    public Vector3 offset;
    public float radiusNotToChase;

    [Header("Movement")]
    public Character4D Character;
    public bool InitDirection;
    public int MovementSpeed;
    private bool moveFromInput;
    private bool _moving;

    private KeyCode activeInputSoul;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        
        moveFromInput = false;
    }

    public void Start()
    {
        GameManager.changeCharacter += SwitchCharacter;
        activeInputSoul = GameManager.instance.GetSwitchCharacterInput();
        Character.AnimationManager.SetState(CharacterState.Idle);
        if (InitDirection)
        {
            Character.SetDirection(Vector2.right);
        }
    }

    public void Update()
    {
        if (moveFromInput)
        {
            SetDirection();
            MoveFromInput();
        }
        else
        {
            Vector2 distance = _player.transform.position - transform.position;
            Vector2 direction = (_player.transform.position - transform.position - offset).normalized;
            if (distance.x > 0)
            {
                FaceRightWay(Vector2.right);
            }
            else
            {
                FaceRightWay(Vector2.left);
            }
            if (_moving == true)
            {
                if (Mathf.Abs(distance.x) - offset.x < 0.15f)
                {
                    Move(Vector2.zero);
                }
                else{
                    Move(direction);
                }
                
            }
            else
            {
                if (Mathf.Abs(distance.x) > radiusNotToChase)
                {
                    Move(direction);
                }
            }
        }
    }

    private void SwitchCharacter()
    {
        moveFromInput = !moveFromInput;
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

    private void FaceRightWay(Vector2 direction)
    {
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
