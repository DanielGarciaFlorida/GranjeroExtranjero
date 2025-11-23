using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int MaxSalud = 3;
    private int SaludActual;
    public int daño = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Awake()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        SaludActual = MaxSalud;
    }

    public void DañoRecibido(int daño)
    {
        if(SaludActual == 0) return;

        SaludActual -= daño;

        if(SaludActual <0) SaludActual = 0;
    }
}
