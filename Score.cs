using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private int score;
	// Use this for initialization
	public void InitScore () {
		this.score = 0;
	}

	public void AddScore(int score){
		this.score += score;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score : " + this.score;
	}
}
