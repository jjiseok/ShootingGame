using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject debri; //우주쓰레기 프리팹
	public float interval=1f; //쓰레기 발생 간격(시간)
	private bool spawnStarted=false;//쓰레기 발생중인지 체크하는 플래그변수 
	void StartSpawn () {
		if (!spawnStarted) {
			spawnStarted = true;
			StartCoroutine ("SpawnDebri");//코루틴의 시작
		}
	}
	void StopSpawn(){
				if (spawnStarted) {
						spawnStarted = false;
						StopCoroutine ("SpawnDebri");//코루틴 정지
				}
	}
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnDebri(){
		while (true) {
			Instantiate (debri, transform.position, Quaternion.identity);
			//Instantiate(원본, 좌표, 각도);
			yield return new WaitForSeconds (interval);
		}
	}
}
