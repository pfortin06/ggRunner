using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	private Vector3 moveDirection;
	private Vector3 actualPosition;
	public float moveSpeed = 5f;
	private Vector3 moveInThisDirection;
	public float jumpingForce = 1000f;
	private bool canJump= false;
	private bool canDoubleJump = false;
	public bool dashing = false;
	private float dashSpeed = 20000f;
	private float dashPosEnd;
	private float coolDownTime = 2;
	private float coolDown;
	public float state;
	
	// Use this for initialization
	void Start () {
		moveDirection = new Vector3 (1, 0, 0);
	;
	}

	public void whatState(float i)
	{
		state = i;
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{

		canJump = true;

	}

	public void OnCollisionEnter2D(Collision2D collision) { 
		if (collision.gameObject.tag == "DestroyableWall" && dashing) { // if the hit object's name is Wall...
			Destroy (collision.gameObject);
		}
	}

	public void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "DestroyableWall" && dashing)
		{ // if the hit object's name is Wall...
			Destroy(collision.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

		if (state == 1) {
			canDoubleJump = false;
			if (Input.GetKeyDown (KeyCode.Q) && coolDown <= Time.time) {	
				dashing = true;
				GetComponent<SpriteRenderer> ().color = Color.red;
				dashPosEnd = GetComponent<Rigidbody2D> ().position.x + 4;
				Vector2 dashVector = new Vector2 (3, 0);
				GetComponent<Rigidbody2D> ().AddForce (dashVector * dashSpeed * Time.deltaTime);
			}
			if (dashing) {
				if (GetComponent<Rigidbody2D>().transform.position.x > dashPosEnd) {
					dashing = false;
					GetComponent<SpriteRenderer>().color = Color.white;
					coolDown = Time.time + coolDownTime;
				}
			}
		} else if (state == 3) {



		}

		if (Input.GetKeyDown ("space") && canJump) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpingForce));
			canJump = false;
			if(state == 2){
				canDoubleJump = true;
			}
		}
		else if (Input.GetKeyDown ("space") && canDoubleJump && state == 2) {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpingForce));
				canDoubleJump = false;
			}



		actualPosition = transform.position;
		moveInThisDirection = moveDirection * moveSpeed + actualPosition;
		transform.position = Vector3.Lerp (actualPosition, moveInThisDirection, Time.deltaTime);
		
	}



}
