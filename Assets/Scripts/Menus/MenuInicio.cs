using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{

	public void Jugar()
	{
		SceneManager.LoadScene("Level_Final");
	}

	public void Salir()
	{
		Application.Quit();
	}
}
