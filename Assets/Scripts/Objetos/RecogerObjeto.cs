using UnityEngine;
using UnityEngine.SceneManagement;
public class RecogerObjeto : MonoBehaviour
{
    [Header("Configuración")]
    public string nombreDeEstaFruta;

    private Contador scriptContador;
    private int frutasRecogidas;
    [SerializeField] private int frutasTotales;

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
            }

            Destroy(gameObject);
            Debug.Log("Has recogido una: " + nombreDeEstaFruta);
            frutasRecogidas++;

            if (frutasRecogidas == frutasTotales)
            {
                Debug.Log("Has recogido todas las frutas");
                SceneManager.LoadScene("Victoria");
            }
        }
    }
}
