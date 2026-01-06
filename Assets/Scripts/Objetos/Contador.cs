using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    private string[] catalogoFrutas = { "Manzana", "Calabaza", "Zanahoria" };

    [Header("Cantidades")]
    public int cantManzanas = 0;
    public int cantCalabazas = 0;
    public int cantZanahorias = 0;

    [Header("UI")]
    public TextMeshProUGUI textoUI;

    public int totalFrutas = 3;
    private int frutasRecogidasGlobal = 0;

    //Método iterativo
    public void ProcesarFrutaRecogida(string nombreFruta)
    {
        bool coincidenciaEncontrada = false;
        for (int i = 0; i < catalogoFrutas.Length; i++)
        {
            if (nombreFruta == catalogoFrutas[i])
            {
                ActualizarCantidad(i);
                coincidenciaEncontrada = true;
                Debug.Log("Has recogido una (Iterativo): " + catalogoFrutas[i]);
                break;
            }
        }
        if (!coincidenciaEncontrada) Debug.LogWarning("La fruta '" + nombreFruta + "' no está en el catálogo.");
        DibujarEnPantalla();
    }

    //Método recursivo 
    public void ProcesarFrutaRecursiva(string nombreFruta, int indice)
    {
     
        if (indice >= catalogoFrutas.Length)
        {
            Debug.LogWarning("La fruta '" + nombreFruta + "' no está en el catálogo.");
            DibujarEnPantalla();
            return;
        }

       
        if (nombreFruta == catalogoFrutas[indice])
        {
            ActualizarCantidad(indice);
            Debug.Log("Has recogido una (Recursivo): " + catalogoFrutas[indice]);
            DibujarEnPantalla();
            return;
        }

      
        ProcesarFrutaRecursiva(nombreFruta, indice + 1);
    }

    void ActualizarCantidad(int indice)
    {
        if (indice == 0) cantManzanas++;
        else if (indice == 1) cantCalabazas++;
        else if (indice == 2) cantZanahorias++;
    }

    void DibujarEnPantalla()
    {
        if (textoUI != null)
            textoUI.text = $"Manzanas: {cantManzanas}\nCalabazas: {cantCalabazas}\nZanahorias: {cantZanahorias}";
    }

	public void FrutaRecogida()
	{
		frutasRecogidasGlobal++;
		Debug.Log("Frutas recogidas: " + frutasRecogidasGlobal);

		if (frutasRecogidasGlobal >= totalFrutas)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Victoria");
		}
	}

}