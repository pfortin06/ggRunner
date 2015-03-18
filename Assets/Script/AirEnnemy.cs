using UnityEngine;
using System.Collections;

public class AirEnnemy : MonoBehaviour {
	private Vector3 moveDirection;
	private Vector3 moveAfterAttack;
	private Vector3 actualPosition;
	private float moveSpeed = 3f;
	private Vector3 moveInThisDirection;
	private Vector3 newDirection;
	Vector3 playerPosition;
	void Start () {
		moveDirection = new Vector3 (0, 0, 0);
		moveAfterAttack = new Vector3 (-1, 1, 0);
	}
	int inRange()
	{
		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
		float range =  actualPosition.x-playerPosition.x ;
		
		if (range < 10 && range > 5)
			return 1;
		else if (range <= 5 && range >= 0)
			return 2;
		else if (range < 0)
			return 3;
	
		return 4;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		actualPosition = transform.position;
		
		
		if (inRange () == 1) {
			newDirection = playerPosition - actualPosition;
			transform.position = Vector3.Lerp (actualPosition, newDirection, Time.deltaTime);
		}else if (inRange () == 2) {
			moveInThisDirection = new Vector3(playerPosition.x,-4)  - actualPosition;
			transform.position = Vector3.Lerp (actualPosition, moveInThisDirection, Time.deltaTime);
		}else if (inRange () == 3) {
			moveInThisDirection = moveAfterAttack * moveSpeed + actualPosition;
			transform.position = Vector3.Lerp (actualPosition, moveInThisDirection, Time.deltaTime);
		} 
		else {
			moveInThisDirection = moveDirection * moveSpeed + actualPosition;
			transform.position = Vector3.Lerp (actualPosition, moveInThisDirection, Time.deltaTime);
		}
	}
	
}
