using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {

	[SerializeField] private float speed = 25f;
	private bool canMove = true;

	public float Speed { get { return speed; } set { speed = value; } }
	public bool CanMove { get { return canMove; } set { canMove = value; } }

	public void Move(float x, float y)
    {
		if (canMove)
		{
			Vector3 moveDir = new Vector3(x, y);
			transform.position += moveDir * speed * Time.deltaTime;
		}
	}
}
