using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.Events;

public class MenuVictoria : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI victory;
    [SerializeField] Button restartButton;

    public void Start()
    {
        UnityEvent restart = new UnityEvent();
        restartButton.onClick.AddListener(Restart);
    }
    
    public void Restart()
    {
        Debug.Log("Reiniciando el nivel...");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_Final");
    }
}
