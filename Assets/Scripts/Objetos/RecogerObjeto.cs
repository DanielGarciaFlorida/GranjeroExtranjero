using UnityEngine;
using UnityEngine.SceneManagement;
public class RecogerObjeto : MonoBehaviour
{
    [Header("Configuración")]
    public string nombreDeEstaFruta;

    private Contador scriptContador;

    void Start()
    {
       scriptContador = Object.FindAnyObjectByType<Contador>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            if (scriptContador != null)
            {
                scriptContador.ProcesarFrutaRecogida(nombreDeEstaFruta);
                scriptContador.FrutaRecogida();
            }

            Destroy(gameObject);
            Debug.Log("Has recogido una: " + nombreDeEstaFruta);
        }
    }
}
