using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AlienScript : MonoBehaviour
{
    private GameObject UI;
    private CanvasScript UIScrip;
    private Animator AlienAnimator;
    public Transform target;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager");
        UIScrip = UI.GetComponent<CanvasScript>();
        AlienAnimator = gameObject.GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        Speed = 2;
        AlienAnimator.Play("Apearing");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = transform.position - target.position;
        AlienAnimator.SetBool("Moving", false);


        if (direction.sqrMagnitude < 30f)
    {
        transform.Translate(direction.normalized * Time.deltaTime * Speed, Space.World);
        transform.forward = direction.normalized;
        AlienAnimator.SetBool("Moving", true);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("AAAA");

        if (other.gameObject.tag == "Net")
        {
            //Debug.Log("Net");
            UIScrip.Points = UIScrip.Points + 5;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Crater")
        {            
            Destroy(this.gameObject);
        }
    }
}
