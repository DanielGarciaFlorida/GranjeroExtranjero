using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    
    [SerializeField] private int lives = 3;
    [SerializeField] private int maxLives = 3;

    
    public RawImage[] fullHearts;
    
    public RawImage[] emptyHearts;

    private void OnValidate()
    {
        
        if (maxLives < 1) maxLives = 1;
        if (lives > maxLives) lives = maxLives;
    }

    private void Start()
    {
        
        if (fullHearts == null || emptyHearts == null)
        {
            
            return;
        }

        if (fullHearts.Length < maxLives || emptyHearts.Length < maxLives)
        {
            
            return;
        }

        
        lives = Mathf.Clamp(lives, 0, maxLives);

        
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        
        if (fullHearts == null || emptyHearts == null) return;

        for (int i = 0; i < maxLives; i++)
        {
            bool alive = i < lives;

            
            if (fullHearts.Length > i && fullHearts[i] != null)
                fullHearts[i].enabled = alive;

            if (emptyHearts.Length > i && emptyHearts[i] != null)
                emptyHearts[i].enabled = !alive;
        }
    }
    public void TakeDamage(int amount = 1)
    {
        if (amount <= 0) return;
        int old = lives;
        lives = Mathf.Clamp(lives - amount, 0, maxLives);

        if (lives != old)
        {
            UpdateHearts();
            
        }
    }
    public void Heal(int amount = 1)
    {
        if (amount <= 0) return;
        lives = Mathf.Clamp(lives + amount, 0, maxLives);
        UpdateHearts();
    }
    public static HeartsUI FindInstance()
    {       
        return Object.FindFirstObjectByType<HeartsUI>();
	}
}
