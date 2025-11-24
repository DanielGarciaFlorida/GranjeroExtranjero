using UnityEngine;
using UnityEngine.UI;

public class VidaDisplay : MonoBehaviour
{

    
    public int lives = 3;       
    public int maxLives = 3;    

    
    public RawImage[] fullHearts;  
    public RawImage[] emptyHearts; 

    public void UpdateHearts()
    {
        for (int i = 0; i < maxLives; i++)
        {
            if (i < lives)
            {
                fullHearts[i].enabled = true;
                emptyHearts[i].enabled = false;
            }
            else
            {
                fullHearts[i].enabled = false;
                emptyHearts[i].enabled = true;
            }
        }
    }

    public void TakeDamage()
    {
        if (lives > 0)
        {
            lives--;
            UpdateHearts();
        }
    }
}
