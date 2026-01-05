using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuVictoria : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI victory;
    [SerializeField] Button restartButton;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Victory()
    {
        gameObject.SetActive(true);
        if(restartButton)
        {
            Restart();
        }
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_Final");
    }
}
