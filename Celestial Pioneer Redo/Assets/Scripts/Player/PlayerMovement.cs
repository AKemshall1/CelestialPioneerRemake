using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Ship player;

	Rigidbody2D rb;
	Vector2 noInput;
	InputMaster controls;
	private void Awake()
	{
		controls = new InputMaster();
		controls.Player.Movement.performed += cnt => Movement(cnt.ReadValue<Vector2>());

		noInput = new Vector2(0.0f, 0.0f);
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (transform.position.x >= player.xRight)
		{
			transform.position = new Vector2(player.xLeft, transform.position.y);
		}
		else if (transform.position.x <= player.xLeft)
		{
			transform.position = new Vector2(player.xRight, transform.position.y);
		}

		if (controls.Player.Movement.ReadValue<Vector2>() == noInput)
		{
			rb.velocity = noInput;
		}
	}

	void Movement(Vector2 direction)
	{
		//Debug.Log("Player wants to move" + direction);
		rb.velocity = direction * player.moveSpeed;
	}

	private void OnEnable()
	{
		controls.Enable();
	}

	private void OnDisable()
	{
		controls.Disable();
	}
}
