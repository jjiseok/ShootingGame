using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUITexture guiTitle;
	public GUITexture guiTimeup;

	public enum GameState{
		TITLE,
		PLAYING,
		TIMEUP,
		TIME_TO_TITLE,
	}

	private GameState state; //GameState형으로 state생성
	private GameObject spawnPoint; 
	private GameObject score;
	private Timer timer;

	// Use this for initialization
	void Start () {
		state = GameState.TITLE;//
		guiTitle.enabled = true;
		guiTimeup.enabled = false;
		spawnPoint = GameObject.Find ("SpawnPoint");
		score = GameObject.Find ("Score");
		timer = GameObject.Find ("Timer").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
				switch (state) {
				case GameState.TITLE:
						if (Input.GetMouseButton (0)) {
								state = GameState.PLAYING;
								spawnPoint.SendMessage ("StartSpawn");
				score.SendMessage ("InitScore");

								timer.StartTimer ();
								guiTitle.enabled = false;
						}
						break;

				case GameState.PLAYING:
						if (timer.GetTimeRemaining () == 0) {
								state = GameState.TIMEUP;
								spawnPoint.SendMessage ("StopSpawn");
								timer.StopTimer ();
								guiTimeup.enabled = true;
								DestroyAllDebri ();

						}
						break;

				case GameState.TIMEUP:
						if (Input.GetMouseButton (0)) {
								state = GameState.TIME_TO_TITLE;
								StartCoroutine ("ShowTitleDelayed", 3f);
						}
			break;
		
				}
		}

	IEnumerator ShowTitleDelayed(float delayTime){
		yield return new WaitForSeconds (delayTime);
		state = GameState.TITLE;
		timer.ResetTimer ();
		guiTitle.enabled=true;
		guiTimeup.enabled=false;

	}



	void DestroyAllDebri(){
		GameObject[] debris = GameObject.FindGameObjectsWithTag ("debri");
		foreach (GameObject debri in debris) {
			Destroy (debri);
		}

	}



}
