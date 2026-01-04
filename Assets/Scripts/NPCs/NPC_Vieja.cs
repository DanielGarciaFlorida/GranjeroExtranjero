using UnityEngine;
using TMPro;
using System.Collections;

public class NPC_Vieja : MonoBehaviour
{
    Collider2D npcCollider;
    [SerializeField] public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed = 0.05f;
    private int index = 0;

    void Start()
    {
        dialogueText.text = string.Empty;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC_Vieja trigger.");

            StartDialogue();

            if (Input.GetMouseButtonDown(0))
            {
                if (dialogueText.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = lines[index];
                }
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
