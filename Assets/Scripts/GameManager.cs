using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private GUIStyle labelStyle;
	int[,] field;
	bool isRunning;
	public GameObject blockPrefab;
	int score;
	public int maxHeight;
	float interval;

	// Use this for initialization
	void Start () {
		//Random.InitState(0);
		field = new int[3, 3];
		isRunning = true;
		score = 0;
		maxHeight = 0;
		interval = 3;

		this.labelStyle = new GUIStyle();
		this.labelStyle.fontSize = Screen.height / 22;
		this.labelStyle.normal.textColor = Color.white;

		StartCoroutine("fallBlock");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver()
	{
		StopCoroutine("fallBlock");
	}

	public int height(int x,int y)
	{
		return field[x, y];
	}

	public void AddScore(int add)
	{
		score += add;
		if(score > 5000)
		{
			interval = 2.5f;
		}
		else if (score > 10000)
		{
			interval = 2.0f;
		}
		else if (score >15000)
		{
			interval = 1.5f;
		}
		else if (score > 20000)
		{
			interval = 1.0f;
		}
	}

	IEnumerator fallBlock()
	{
		while (true)
		{
			int x = (int)(Random.value * 3) % 3;
			int y = (int)(Random.value * 3) % 3;
			field[x, y]++;
			GameObject block = Instantiate(blockPrefab);
			block.transform.position = new Vector3(-1 + x, maxHeight + 20, -1 + y);
			yield return new WaitForSeconds(interval);
		}
	}

	private void OnGUI()
	{
		float x = Screen.width / 10;
		float y = Screen.height / 10;
		float w = Screen.width * 8 / 10;
		float h = Screen.height / 20;

		GUI.Label(new Rect(x, y, w, h), "Score: " + score, labelStyle);
		GUI.Label(new Rect(x, y + h, w, h), "Max Height: " + maxHeight, labelStyle);
	}
}