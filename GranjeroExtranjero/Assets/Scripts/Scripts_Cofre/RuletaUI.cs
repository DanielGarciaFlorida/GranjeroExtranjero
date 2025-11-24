using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RuletaUI : MonoBehaviour
{
    public Image[] skillPanels;            
    public Color normalColor = Color.gray;
    public Color selectedColor = Color.yellow;

    public float startSpeed = 0.05f;     
    public float slowDownFactor = 1.03f; 
    public float maxDelay = 0.35f;       

    private int selectedIndex = 0;

    public IEnumerator PlayRoulette()
    {
        float delay = startSpeed;

        
        ResetColors();

        while (delay < maxDelay)
        {
            
            selectedIndex = (selectedIndex + 1) % skillPanels.Length;

            
            ResetColors();
            skillPanels[selectedIndex].color = selectedColor;

            
            yield return new WaitForSeconds(delay);

            
            delay *= slowDownFactor;
        }

        
        yield break;
    }

    public int GetSelectedSkill()
    {
        return selectedIndex;
    }

    private void ResetColors()
    {
        foreach (Image panel in skillPanels)
            panel.color = normalColor;
    }
}
