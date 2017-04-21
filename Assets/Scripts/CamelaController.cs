using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamelaController : MonoBehaviour {
	GameObject human;
	int pos_id;
	float[,] pos;

	// Use this for initialization
	void Start () {
		human = GameObject.Find("Human");
		pos_id = 0;
		pos = new float[,] { { 0, -5 }, { 5, 0 }, { 0, 5 }, { -5, 0 } };
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, human.transform.position.y + 4.5f, transform.position.z);
		if (Input.GetKeyDown(KeyCode.X))
		{
			pos_id = (pos_id + 1) % 4;
			transform.position = new Vector3(pos[pos_id, 0], transform.position.y, pos[pos_id, 1]);
			transform.Rotate(0, -90, 0, Space.World);
			human.transform.Rotate(0, -90, 0);
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			pos_id = (pos_id + 3) % 4;
			transform.position = new Vector3(pos[pos_id, 0], transform.position.y, pos[pos_id, 1]);
			transform.Rotate(0, 90, 0, Space.World);
			human.transform.Rotate(0, 90, 0);
		}
	}
}
