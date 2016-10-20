using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public Vector3 angle;
	// Use this for initialization
	void Start () {
		angle.y = 10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (angle * Time.deltaTime);
	}
}
