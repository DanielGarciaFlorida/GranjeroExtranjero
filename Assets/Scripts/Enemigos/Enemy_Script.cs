using UnityEngine;


public class Enemy_Script : MonoBehaviour
{
    [Header("configración del enemigo")]
     private float speed = 3f;            
     private float detectionRange = 5f;   
     private float stopDistance = 1.2f;
    private float obstacleDetectionDistance = 0.5f;
	private float obstacleStepHeight = 0.5f;

	[Header("Referencia al jugador")]
    public Transform player;

    private void Update()
    {
        if (player == null) return;

        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance <= detectionRange && distance > stopDistance)
        {
            //Decisión voraz: moverse en la dirección que reduce la distancia al jugador
            float directionX = Mathf.Sign(player.position.x - transform.position.x);
            
            Vector2 origin = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = new Vector2(directionX, 0f);

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, obstacleDetectionDistance);

            if (hit.collider != null)
            {
				transform.position += new Vector3(directionX * speed * Time.deltaTime, obstacleStepHeight * Time.deltaTime, 0f);
			}
            else
            {
				transform.position += new Vector3(directionX * speed * Time.deltaTime, 0f, 0f);
			}

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * directionX;
            transform.localScale = scale;
        }
    }

	private void OnDrawGizmos()
	{
		if ( player == null ) return;

        float directionX = Mathf.Sign(player.position.x - transform .position.x);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(directionX * obstacleDetectionDistance, 0f, 0f));
    }
}
