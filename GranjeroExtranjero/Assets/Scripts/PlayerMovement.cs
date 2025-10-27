using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//public Vector3 initialPosition;
	public float speed;
	public float gravity;
	public float impulse;
	public float groundLevel;

	public bool isGrounded = true;

	void Start()
	{

		//initialPosition = transform.position;
		speed = 5f;
		gravity = 9.8f;
		impulse = 7.0f;
		groundLevel = -4.5f;
	}

	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		transform.position += new Vector3(moveHorizontal * 5f * Time.deltaTime, 0, 0);

		if (!isGrounded)
		{
			speed -= gravity * Time.deltaTime;
			transform.position += Vector3.up * speed * Time.deltaTime;
		}

		if (transform.position.y <= groundLevel)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y);
			speed = 0f;
			isGrounded = true;
		}

		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			speed = impulse;
			isGrounded = false;
		}

	
	}
}


