using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int timeLimit=30;//남은시간 초기값
	private float timeRemaining;//남은시간
	private bool timerStarted;//타이머 동작플래그
	// Use this for initialization
	void Start () {
		ResetTimer ();
	}

	public void ResetTimer(){//타이머 초기화
		timeRemaining = timeLimit;
		timerStarted = false;
	}

	public void StartTimer(){
		timerStarted = true;
	}

	public void StopTimer(){
		timerStarted = false;
	}
	public float GetTimeRemaining(){
		return timeRemaining;
	}


	// Update is called once per frame
	void Update () {
		if (timerStarted == true) {
			timeRemaining-=Time.deltaTime;
			if(timeRemaining<=0){
				timeRemaining=0;
				timerStarted=false;
			}
		}
		guiText.text = "Time : " + this.timeRemaining;
	}
}
