using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private Movement movement;
	private Destroyer destroyer;

	void Awake()
    {
		movement = GetComponent<Movement>();
		destroyer = GetComponent<Destroyer>();
    }

	// Use this for initialization
	void Start () {
		destroyer.ResetPositions();
	}
	
	// Update is called once per frame
	void Update () {
		movement.Move(0f, -1f);
	}
}
