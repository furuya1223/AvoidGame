using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControl : MonoBehaviour {
	float speed = 2f;
	float jumpPower = 300f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		transform.position += (transform.forward * v + transform.right * h) * speed * Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(0, jumpPower, 0);
		}
	}
}
