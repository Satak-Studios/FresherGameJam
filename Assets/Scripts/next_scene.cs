using UnityEngine;
using UnityEngine.SceneManagement;

public class next_scene : MonoBehaviour
{
    // Start is called once before
    //  the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("level 1");
    }
}
