using UnityEngine;

public class end_trigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerMovement move = other.GetComponent<playerMovement>();
            move.inversion_probability = 0;
        }
    }
}

