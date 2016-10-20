using UnityEngine;
using System.Collections;

public class Debri : MonoBehaviour {
	public float angle=30f; //1초당 회전 각도
	public int score=10; //점수
	private Vector3 targetPos; //회전의 중심좌표
	// Use this for initialization
	void Start () {
		Transform target = GameObject.Find ("Earth").transform;
		// 게임오브젝트의 Earth의 transform 정보를 target으로 저장 
		targetPos = target.position; // Earth의 위치정보 저장
		transform.LookAt (target);//우주 쓰레기의 정면방향 Earth의 방향을 바꿈
		transform.Rotate (new Vector3 (0, 0, Random.Range (0, 360)), Space.World);
		//우주 쓰레기를 0도에서 360도 범위로 z축으로 회전
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 axis = transform.TransformDirection (Vector3.up);
		//Earth를 중심으로 우주 쓰레기를 현재의 위쪽으로 1초당 angle만큼 회전
		transform.RotateAround (targetPos, axis, angle * Time.deltaTime);
	}

	void OnMouseDown(){
		GameObject.Find ("Score").SendMessage ("AddScore", score);
		Destroy (gameObject);//클릭하면 객체 삭제
	}
}
