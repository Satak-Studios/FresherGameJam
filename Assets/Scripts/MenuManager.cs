using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            Debug.Log("You are an old player");
            SceneManager.LoadScene(1);
        }
    }

    public void Options()
    {
        //Temporary
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
