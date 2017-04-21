using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	Rigidbody rb;
	bool isFalling;
	bool isTrod;
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		isFalling = true;
		isTrod = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (isFalling && collision.gameObject.tag == "Field")
		{
			// ブロック落下終了
			gameManager.AddScore(100);
			rb.constraints = RigidbodyConstraints.FreezeAll;
			isFalling = false;
			transform.position = new Vector3(
				transform.position.x,
				(int)transform.position.y + 0.5f,
				transform.position.z);
		}
		else if (collision.gameObject.tag == "Player")
		{
			if (isFalling)
			{
				// ゲームオーバー
				rb.constraints = RigidbodyConstraints.FreezeAll;
				isFalling = false;
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				gameManager.GameOver();
			}
			else
			{
				if (collision.gameObject.transform.position.y - transform.position.y > 0.9)
				{
					// 踏んだ
					if (!isTrod)
					{
						// 初めて踏んだ
						gameManager.AddScore(50);
						gameObject.GetComponent<Renderer>().material.color = new Color(0.4f, 0.4f, 0.8f);
						isTrod = true;
					}
					// 座標計算
					int x = (int)(transform.position.x + 1.5);
					int y = (int)(transform.position.z + 1.5);
					if(gameManager.height(x,y) > gameManager.maxHeight)
					{
						// 高さ記録更新
						gameManager.maxHeight = gameManager.height(x, y);
						gameManager.AddScore(500);
					}
				}
			}
		}
	}
}
