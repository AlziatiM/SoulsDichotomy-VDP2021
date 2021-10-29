using UnityEngine;
using Assets.HeroEditor4D.Common.CharacterScripts;
using HeroEditor4D.Common.Enums;

[RequireComponent(typeof(PlayerVelocity))]
public class PlayerInput : MonoBehaviour
{
	public Character4D Character;

	private PlayerVelocity playerVelocity;
	public bool InitDirection;

	private CharacterState currState;
	private bool isJumping;
	private bool _moving;
	void Start()
	{
		isJumping = false;
		playerVelocity = GetComponent<PlayerVelocity>();
		Character.AnimationManager.SetState(CharacterState.Idle);
		currState = CharacterState.Idle;
		if (InitDirection)
		{
			Character.SetDirection(Vector2.left);
		}
	}
	void Update()
	{
		SetDirection();

		Move();

	}

	private void Move()
	{

		var direction = Vector2.zero;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			direction += Vector2.left;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			direction += Vector2.right;
		}
		playerVelocity.SetDirectionalInput(direction);
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			ChangeAnimation(CharacterState.Jump);
			isJumping = true;
			playerVelocity.OnJumpInputDown();
			
		}
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			playerVelocity.OnJumpInputUp();
			
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			playerVelocity.OnFallInputDown();
		}

        if (isJumping)
        {
			return;
        }
		if (direction == Vector2.zero)
		{
			if (_moving)
			{
				ChangeAnimation(CharacterState.Idle);
				_moving = false;
			}
		}
		else
		{
			ChangeAnimation(CharacterState.Run);
			_moving = true;
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

	public void ChangeAnimation(CharacterState state)
    {
		Character.AnimationManager.SetState(state);
	}

	public void BackOnTheFloor()
    {
		isJumping = false;
		if (!_moving)
		{
			ChangeAnimation(CharacterState.Idle);
		}
	}

	public bool GetMoving()
	{
		return _moving;
	}
}
