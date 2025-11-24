using UnityEngine;

public class RecogerObjeto : MonoBehaviour
{
    Inventario inventario;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        inventario.Cantidad = inventario.Cantidad + 1;
        Destroy(gameObject);
        }
    }

}
