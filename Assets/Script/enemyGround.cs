using UnityEngine;
using System.Collections;

public class enemyGround : MonoBehaviour {
	public float moveSpeed =-3.0f;
	private float startTime;
	private float timeElapsed;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, 0);
		
	}
}
