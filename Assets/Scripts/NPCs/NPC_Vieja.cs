using UnityEngine;
using System.Collections;

public class NPC_Vieja : MonoBehaviour
{
    public Transform player;
    public GameObject messageUI;
    public bool messageShowm = false;
    public float displayTime = 3f;

    public
    void Start()
    {
       if (messageUI != null)
        {
            messageUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player && !messageShowm)
        {
            messageUI.SetActive(true);
            messageShowm = true;
            StartCoroutine(HideMessageAfterTime() );
        }
    }
    
    private IEnumerator HideMessageAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        if (messageUI != null)
        {
            messageUI.SetActive(false );
        }
    }
}
