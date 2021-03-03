using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Header("Components")]
	[SerializeField] private Transform gfx;
	private Movement movement = null;
	private UI userInterface;

	[Header("Health")]
	private int health = 1;

	public Movement Movement { get { return movement; } }

	// Use this for initialization
	public void SetUpComponents () {
		movement = GetComponent<Movement>();

		if (GameController.instance)
			userInterface = GameController.instance.UserInterface;
	}
	
	void Start()
    {
		if (GameData.instance)
		{
			health = GameData.instance.currentSkin.health;
			movement.Speed = GameData.instance.currentSkin.speed;

			userInterface.SetCoinUI(GameData.instance.playerData.coins);
		}

		userInterface.SetHealthUI(health);
	}

	// Update is called once per frame
	void Update () {
		MoveInput();
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, GameController.instance.leftLimit, GameController.instance.rightLimit), Mathf.Clamp(transform.position.y, GameController.instance.bottomLimit, GameController.instance.topLimit), transform.position.z);
	}

	void MoveInput()
    {
		float x = Input.GetAxis("Horizontal");
		if(x > 0)
        {
			gfx.localScale = new Vector3(1, gfx.localScale.y, gfx.localScale.z);
        }
		else if (x < 0)
        {
			gfx.localScale = new Vector3(-1, gfx.localScale.y, gfx.localScale.z);
		}

		movement.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
	public void AddCoin()
	{
		GameController.instance.AddCoins(1);
	}

	public void TakeDamage(int value)
    {
		if (health - value == 0)
        {
			Die();
        }
		else
        {
			health -= value;
        }
		userInterface.SetHealthUI(health);
	}

	public void Die()
    {
		print("Player died!");
		GameController.instance.GameOver();
    }
}
