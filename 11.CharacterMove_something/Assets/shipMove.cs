using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMove : MonoBehaviour {

	float moveForce;
	Rigidbody2D rb;
	//public float speed;


	// Use this for initialization
	void Start () {
		moveForce = 20;
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.AddTorque (1, ForceMode2D.Impulse);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddTorque (-1, ForceMode2D.Impulse);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddForce (transform.up * moveForce);
		}
	
	}


		
}