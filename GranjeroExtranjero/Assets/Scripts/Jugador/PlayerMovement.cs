using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;       
	public float gravity;      
	public float impulse;      
	public float groundY;     

	private bool isGrounded = true;

	void Start()
	{
		speed = 5.0f;
		gravity = 9.8f;
		impulse = 8.5f;
		groundY = -4.5f;
	}

	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		transform.position += new Vector3(moveHorizontal * Time.deltaTime * 5f, 0, 0);
		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			speed = impulse;
			isGrounded = false;
		}


		if (!isGrounded)
		{
			speed -= gravity * Time.deltaTime;
			transform.position += Vector3.up * speed * Time.deltaTime;

		}	
			if (transform.position.y <= groundY)
			{
				transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
				isGrounded = true;
				speed = 0f; new Vector2(transform.position.x, transform.position.y);
		}

	}
}
