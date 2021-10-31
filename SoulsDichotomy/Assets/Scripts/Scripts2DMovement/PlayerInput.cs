using UnityEngine;
using Assets.HeroEditor4D.Common.CharacterScripts;
using HeroEditor4D.Common.Enums;

[RequireComponent(typeof(PlayerVelocity))]
public class PlayerInput : MonoBehaviour, IHittable
{
 
	[Header("Movements References")]
	public Character4D Character;
	private PlayerVelocity playerVelocity;
	public bool InitDirection;

	[Header("Soul Objects")]
	public SpriteRenderer areaMovement;

	//manage different character input

	private bool canMove;

	private CharacterState currState;
	private bool isJumping;
	private bool _moving;

	public Health playerHealth;

	private void Awake()
	{
		ShowAreaSoul(false);
		playerHealth.SetUpHealth();
		canMove = true;
		isJumping = false;
		playerVelocity = GetComponent<PlayerVelocity>();
		
	}

	void Start()
	{
		GameManager.changeCharacter += SwitchCharacter;

		Character.AnimationManager.SetState(CharacterState.Idle);
		currState = CharacterState.Idle;
		if (InitDirection)
		{
			Character.SetDirection(Vector2.left);
		}
	}
	void Update()
	{
		if (!canMove)
		{
			return;
		}
		SetDirection();
		Move();
	}

	private void SwitchCharacter()
    {
		canMove = !canMove;
		StopCharacter();
		ShowAreaSoul(!canMove);
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
				StopCharacter();
			}
		}
		else
		{
			ChangeAnimation(CharacterState.Run);
			_moving = true;
		}
	}

	private void StopCharacter()
    {
		playerVelocity.SetDirectionalInput(Vector2.zero);
		ChangeAnimation(CharacterState.Idle);
		_moving = false;
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

	private void ShowAreaSoul(bool show)
    {
		areaMovement.enabled = show;
    }

	public void Hit(int amount)
    {
		playerHealth.SubtractHp(amount);
    }

}
