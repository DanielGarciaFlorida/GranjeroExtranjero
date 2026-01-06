using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    private HeartsUI hearts;

    public int salud;
    public int maxSalud = 3;

    
    public SpriteRenderer jugadorSR;
    public PlayerMovement playermovement;

    
    public string MenuDerrota = "Derrota";

    private bool isDead = false;

    private void Start()
    {
        hearts = HeartsUI.FindInstance();
        if (hearts == null)
            Debug.LogWarning("[VidaJugador] No se encontró HeartsUI en la escena.");

        salud = maxSalud;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RecibirDaño(1);

            if (hearts != null)
                hearts.TakeDamage(1);
            else
                Debug.LogWarning("[VidaJugador] hearts es null — no se restó vida.");
        }
    }

    public void RecibirDaño(int amount)
    {
        if (isDead) return;

        salud -= amount;

        if (salud == 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        isDead = true;

        
        jugadorSR.enabled = false;
        playermovement.enabled = false;

        
        SceneManager.LoadScene(MenuDerrota);
    }
}