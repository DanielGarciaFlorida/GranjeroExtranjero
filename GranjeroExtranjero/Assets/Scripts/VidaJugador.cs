using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int salud;
    public int maxSalud = 3;

    public SpriteRenderer jugadorSR;
    public PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        salud = maxSalud; 

    }

    public void RecibirDaño(int amount)
    {
        salud -= amount;
        if(salud <= 0)
        {
            jugadorSR.enabled = false;
            playerMovement.enabled = false;
        }
    }


}
