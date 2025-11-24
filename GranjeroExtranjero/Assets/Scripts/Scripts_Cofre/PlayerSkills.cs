using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public bool doubleJump = false;
    public bool speedBoost = false;
    public bool highJump = false;
    public bool dash = false;

    private PlayerMovement movement; 

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void UnlockSkill(int id)
    {
        switch (id)
        {
            case 0:
                doubleJump = true;
                Debug.Log("Habilidad desbloqueada: DOBLE SALTO");
                break;

            case 1:
                speedBoost = true;
                movement.speed += 2f;
                Debug.Log("Habilidad desbloqueada: VELOCIDAD +");
                break;

            case 2:
                highJump = true;
                movement.impulse += 5f;
                Debug.Log("Habilidad desbloqueada: SALTO ALTO");
                break;

            case 3:
                dash = true;
                Debug.Log("Habilidad desbloqueada: DASH");
                break;
        }
    }
}