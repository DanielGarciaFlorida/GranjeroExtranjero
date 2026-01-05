using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
	public float gravity;
	public float jumpImpulse;
	public float jumpsLeft;
	public float maxJumps = 2;

	public Transform groundCheck;
	public LayerMask groundLayer;
	public float groundCheckRadius = 0.1f;

	private float verticalVelocity = 0f;
	private bool isGrounded;
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		moveSpeed = 5f;
		gravity = 9.8f;
		jumpImpulse = 9.2f;
		verticalVelocity = 0f;
		//jumpsLeft = 2;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		transform.position +=  Vector3.right * moveHorizontal * moveSpeed * Time.deltaTime;

		if (moveHorizontal != 0)
		{
			spriteRenderer.flipX = moveHorizontal > 0;
		}

		isGrounded = Physics2D.OverlapCircle( groundCheck.position, groundCheckRadius, groundLayer );

		/*if (isGrounded && verticalVelocity < 0)
		{
			verticalVelocity = 0f;
		}
		*/

		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			verticalVelocity = jumpImpulse;
		}

		if (!isGrounded)
		{
			verticalVelocity -= gravity * Time.deltaTime;
			//transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
		}
		else if (verticalVelocity < 0f)
		{
			verticalVelocity = 0;
		}

		transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
	}

	private void OnDrawGizmosSelected()
	{
		if (groundCheck == null) return;
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}

}
