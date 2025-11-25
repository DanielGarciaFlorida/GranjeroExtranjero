using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    private HeartsUI hearts;
    public int salud;
    public int maxSalud = 3;

    public SpriteRenderer jugadorSR;
    public PlayerMovement playermovement;


    private void Start()
    {
        hearts = HeartsUI.FindInstance(); // mejor cachear la referencia
        if (hearts == null) Debug.LogWarning("[PlayerDamageOnHit] No se encontró HeartsUI en la escena.");

        salud = maxSalud;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (hearts != null) hearts.TakeDamage(1);
            else Debug.LogWarning("[PlayerDamageOnHit] hearts es null — no se restó vida.");
        }
    }

    public void RecibirDaño(int amount)
    {
        salud -= amount;
        if (salud <= 0)
        {
            jugadorSR.enabled = false;
            playermovement.enabled = false;
        }
    }
}