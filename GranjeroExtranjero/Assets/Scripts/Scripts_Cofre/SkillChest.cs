using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SkillChest : MonoBehaviour
{
    public GameObject interactText;    
    public GameObject rouletteUI;      
    public float rouletteTime = 2f;

    public GameObject RuletaUI;
    private RuletaUI roulette;

    private bool playerNearby = false;
    private bool chestOpened = false;

    private PlayerSkills playerSkills;

    public void Start()
    {
        roulette = rouletteUI.GetComponent<RuletaUI>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !chestOpened)
        {
            playerNearby = true;
            interactText.SetActive(true);
            playerSkills = collision.GetComponent<PlayerSkills>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
            interactText.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerNearby && !chestOpened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        chestOpened = true;
        interactText.SetActive(false);
        StartCoroutine(StartRoulette());
    }

    public IEnumerator StartRoulette()
    {
        rouletteUI.SetActive(true);

        
        yield return StartCoroutine(roulette.PlayRoulette());

        
        int selectedSkill = roulette.GetSelectedSkill();

        
        playerSkills.UnlockSkill(selectedSkill);

        rouletteUI.SetActive(false);
    }
}