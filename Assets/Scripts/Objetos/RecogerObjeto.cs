using UnityEngine;
using UnityEngine.UI;

public class RecogerObjeto : MonoBehaviour
{

    public SpriteRenderer objetoSR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objetoSR = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objetoSR.enabled = false;
            Destroy(this.gameObject);
        }
    }

}
