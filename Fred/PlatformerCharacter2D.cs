using UnityEngine;
using System.Collections;

namespace UnitySampleAssets._2D
{

    public class PlatformerCharacter2D : MonoBehaviour
    {
        private bool facingRight = true; // For determining which way the player is currently facing.

        [SerializeField] private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
        [SerializeField] private float jumpForce = 200f; // Amount of force added when the player jumps.	

        [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
                                                     // Amount of maxSpeed applied to crouching movement. 1 = 100%

        [SerializeField] private bool airControl = false; // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character

        private Transform groundCheck; // A position marking where to check if the player is grounded.
        private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool grounded = false; // Whether or not the player is grounded.
        private Transform ceilingCheck; // A position marking where to check for ceilings
        private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator anim; // Reference to the player's animator component.
		private bool canDoubleJump = false;
		private bool dashing = false;
		private float dashSpeed = 20000f;
		private float dashPosEnd;
		public float coolDownTime = 2;
		private float coolDown;




        private void Awake()
        {
            // Setting up references.
            groundCheck = transform.Find("GroundCheck");
            ceilingCheck = transform.Find("CeilingCheck");
            anim = GetComponent<Animator>();
        }


        private void FixedUpdate()
        {
            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
            anim.SetBool("Ground", grounded);

            // Set the vertical animation
            anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

			if (dashing) 
			{
				if(facingRight)
				{
					Vector2 dashVector = new Vector2(5,0);
					rigidbody2D.AddForce (dashVector * dashSpeed * Time.deltaTime);
				}
		
				else
				{
					Vector2 dashVector = new Vector2(-5,0);
					rigidbody2D.AddForce (dashVector * dashSpeed * Time.deltaTime);
				}
			}

        }

		private void Update()
		{
			if (Input.GetKeyDown (KeyCode.Q) && coolDown <= Time.time) 
			{	
				dashing = true;
				if (facingRight)
					dashPosEnd = rigidbody2D.position.x + 4;
				else
					dashPosEnd = rigidbody2D.position.x - 4;
			}
			if (dashing)
			{
				if ((facingRight && rigidbody2D.transform.position.x > dashPosEnd) || (!facingRight && rigidbody2D.transform.position.x < dashPosEnd)) {
					dashing = false;
					coolDown = Time.time + coolDownTime;
				}
			}
		}

        public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
                    crouch = true;
            }

            // Set whether or not the character is crouching in the animator
            anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (grounded || airControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*crouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !facingRight)
                    // ... flip the player.
                    Flip();
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && facingRight)
                    // ... flip the player.
                    Flip();
            }
            // If the player should jump...
            if (jump) {
				if (grounded) {
					rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
					canDoubleJump = true;
					anim.SetBool ("Ground", false);
				}
                
				else if (canDoubleJump && !grounded) {
					rigidbody2D.velocity = new Vector2 (0, 0);
					canDoubleJump = false;
					rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
				}
			}
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

		private void OnCollisionEnter2D(Collision2D collision) { 
			if (collision.gameObject.tag == "DestroyableWall" && dashing){ // if the hit object's name is Wall...
				collision.gameObject.SetActive(false);
			}
		}

    }
}