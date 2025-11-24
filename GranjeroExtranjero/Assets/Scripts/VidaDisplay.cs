using UnityEngine;
using UnityEngine.UI;

public class VidaDisplay : MonoBehaviour
{

    public int salud;
    public int maxSalud;

    public Sprite corazonvacio;
    public Sprite corazonlleno;
    public Image[] corazones;

    public VidaJugador vidaJugador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        salud = vidaJugador.salud;
        maxSalud = vidaJugador.maxSalud;

        for(int i = 0; i < corazones.Length; i++)
        {
          if(i < salud)
          {
              corazones[i].sprite = corazonlleno;
          }
          else
          {
              corazones[i].sprite = corazonvacio;
          }

          if(i < maxSalud)
          {
            corazones[i].enabled = true;
          }
          else
          {
            corazones[i].enabled = false;
          }
        }
    }
}
