using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Movement movement;
	private Destroyer destroyer;

	private bool isMoveRight = false;

	void Awake()
    {
		movement = GetComponent<Movement>();
		destroyer = GetComponent<Destroyer>();
    }

	// Use this for initialization
	void Start () {
		destroyer.ResetPositions();
		ChangeDirection();
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoveRight)
		{
			movement.Move(1f, 0f);
		}
		else
		{
			movement.Move(-1f, 0f);
		}
		
	}

	public void ChangeDirection()
    {
		if(transform.position.x > 0f)
        {
			transform.localScale = new Vector3(transform.localScale.x, -1f, transform.localScale.z);
			transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180, transform.rotation.w);
			isMoveRight = false;
        }
		else
        {
			transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
			transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
			isMoveRight = true;
		}
    }
}
