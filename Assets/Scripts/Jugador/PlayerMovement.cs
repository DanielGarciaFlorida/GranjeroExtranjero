using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
	public float gravity;
	public float jumpImpulse;
	public float groundY;
	public float jumpsLeft;
	public float maxJumps = 2;

	private float verticalVelocity = 0f;
	private bool isGrounded;

	private void Start()
	{
		moveSpeed = 5f;
		gravity = 9.8f;
		jumpImpulse = 8.5f;
		groundY = -4.5f;
		verticalVelocity = 0f;
		//jumpsLeft = 2;
	}
	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, 0);

		if (transform.position.y <= groundY)
		{
			transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
			verticalVelocity = 0f;
			isGrounded = true;
			//jumpsLeft = maxJumps;

		}
		else
		{
			isGrounded = false;
		}

		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			verticalVelocity = jumpImpulse;
			isGrounded = false;
			//jumpsLeft--;
		}

		if (!isGrounded)
		{
			verticalVelocity -= gravity * Time.deltaTime;
			transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
		}
	}
}