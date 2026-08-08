using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string[] lines;
    public string[] speakers;
    public dialogue d;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            d.gameObject.SetActive(true);
            d.StartDialogue(lines,speakers);
            Destroy(gameObject);
        }
    }
}
