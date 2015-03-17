using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	private Vector3 moveDirection;
	private float moveSpeed = 3f;
	
	
	// Use this for initialization
	void Start () {
		moveDirection = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	


		moveDirection = GameObject.FindGameObjectWithTag ("Player").transform.position;
		moveDirection.x += 10;
		moveDirection.z = -10;
		transform.position = moveDirection;
		
	}
	
}
