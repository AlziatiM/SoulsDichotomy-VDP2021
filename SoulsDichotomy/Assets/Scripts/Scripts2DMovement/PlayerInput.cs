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
	public GameObject panelSoulMovement;
	public SpriteRenderer areaMovement;

	//manage different character input

	private bool canMove;

	//input player
	private KeyCode up;
	private KeyCode down;
	private KeyCode right;
	private KeyCode left;
	private KeyCode interact;

	private CharacterState currState;
	private bool isJumping;
	private bool _moving;
	private bool gameOver;
	public bool GameOver { set { gameOver = value; } get { return gameOver; } }
	[Header("Healt Attributes")]
	public Health playerHealth;
	[SerializeField] private ParticlesPlayer particles;


	private Transform _transf;

	private IInteract interactObj;
	private void Awake()
	{
		ShowAreaSoul(false);
		playerHealth.SetUpHealth();
		canMove = true;
		isJumping = false;
		gameOver = false;
		playerVelocity = GetComponent<PlayerVelocity>();
		_transf = this.gameObject.GetComponent<Transform>();
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
		CustomizeInput.changeInput += ChangeCustomizeInput;

	}

	void Update()
	{
		if (gameOver)
			return;
		if (!canMove)
		{
			return;
		}
		SetDirection();
		Move();
		Interaction();
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

        if (Input.GetKey(left))
		{
			direction += Vector2.left;
		}

		if (Input.GetKey(right))
		{
			direction += Vector2.right;
		}
		playerVelocity.SetDirectionalInput(direction);

		if (Input.GetKeyDown(up))
		{
			ChangeAnimation(CharacterState.Jump);
			isJumping = true;
			playerVelocity.OnJumpInputDown();

		}
		if (Input.GetKeyUp(up))
		{
			playerVelocity.OnJumpInputUp();

		}
		if (Input.GetKey(down))
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

	private void Interaction()
    {
        if (interactObj!=null && Input.GetKeyDown(interact))
        {
			interactObj.Interact();
        }
    }

	private void SetDirection()
	{
		Vector2 direction;

		if (Input.GetKeyDown(left))
		{
			direction = Vector2.left;
		}
		else if (Input.GetKeyDown(right))
		{
			direction = Vector2.right;
		}
		else if (Input.GetKeyUp(left) && Input.GetKey(right))
        {
			direction = Vector2.right;
		}
		else if (Input.GetKeyUp(right) && Input.GetKey(left))
        {
			direction = Vector2.left;
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
	public void Heal(int amount)
	{
		playerHealth.AddHp(amount);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		IInteract interact = collision.gameObject.GetComponent<IInteract>();
        if (interact != null)
        {
            if (interact.CanPlayerInteract())
            {
				interactObj = interact;

			}
				
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		IInteract interact = collision.gameObject.GetComponent<IInteract>();
		if (interact != null)
		{
			interactObj = null;
		}
	}

	public void HealExtra()
    {
		particles.HealEffect(_transf);
		Character.AnimationManager.Hit();
		UIManager.instance.SliderPlayer(playerHealth.Percentage());

    }

	public void DamageExtra()
    {
		particles.DamageEffect(_transf);
		UIManager.instance.SliderPlayer(playerHealth.Percentage());
    }

	public void DeathExtra()
	{
		//Character.AnimationManager.Die();
		Character.AnimationManager.SetState(CharacterState.Death);
		currState = CharacterState.Death;
		canMove = false;
		GameManager.instance.SomeoneDie();
	}

	public void SetScaleToSoulPanel(Vector3 newScale)
    {
		panelSoulMovement.transform.localScale = newScale;
    }

    private void OnDestroy()
    {
		GameManager.changeCharacter -= SwitchCharacter;
		CustomizeInput.changeInput -= ChangeCustomizeInput;

	}

	public void ResetPlayer()
    {
	    playerHealth.SetUpHealth();
		Character.AnimationManager.SetState(CharacterState.Idle);
		playerVelocity.enabled = true;
	    canMove = true;
		GameOver = false;
		ShowAreaSoul(false);
	    //todo remove active pickup
    }
	private void ChangeCustomizeInput(KeyCode up, KeyCode down, KeyCode right, KeyCode left, KeyCode interact, KeyCode switchChar)
	{
		this.up = up;
		this.down = down;
		this.right = right;
		this.left = left;
		this.interact = interact;
	}

}
