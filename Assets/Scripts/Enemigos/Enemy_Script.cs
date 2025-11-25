using UnityEngine;


public class Enemy_Script : MonoBehaviour
{
    
     private float speed = 3f;            
     private float detectionRange = 5f;   
     private float stopDistance = 1.2f;

    

    public Transform player;



    private void Start()
    {
        
    }



    private void Update()
    {
        if (player == null) return;

        
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance <= detectionRange && distance > stopDistance)
        {
            
            float directionX = Mathf.Sign(player.position.x - transform.position.x);

            
            transform.position += new Vector3(directionX * speed * Time.deltaTime, 0f, 0f);

            
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * directionX;
            transform.localScale = scale;
        }
    }

    

}
