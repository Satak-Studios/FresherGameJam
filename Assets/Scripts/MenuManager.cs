using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text versionTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        versionTxt.text = "v"+Application.version;
    }

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            Debug.Log("You are an old player");
            SceneManager.LoadScene("LevelManager");
        }
        else
        {
            SceneManager.LoadScene("tutorial");
            Debug.Log("You are a new player");
        }
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

   /* public void Options()
    {
        //Temporary
    }*/

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
