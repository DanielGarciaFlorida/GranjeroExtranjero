using UnityEngine;

public class SkillChest : MonoBehaviour
{
    public GameObject interactText;    
    public GameObject rouletteUI;      
    public float rouletteTime = 2f;

    private bool playerNearby = false;
    private bool chestOpened = false;

    private PlayerSkills playerSkills;

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
            interactText.SetActive(true);
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

    System.Collections.IEnumerator StartRoulette()
    {
        rouletteUI.SetActive(true);

        
        yield return new WaitForSeconds(rouletteTime); // Simula ahora mismo la ruleta, no existe aun, ns si habrá ruleta visualmente ¿?¿??¿

        
        int randomSkill = Random.Range(0, 4); // Elige la habilidad random

        
        playerSkills.UnlockSkill(randomSkill); // Aplicar la habilidad que tocó al jugador

         
        rouletteUI.SetActive(false); // Oculta la ruleta
    }
}