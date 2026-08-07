using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;

    public GameObject secondCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindAnyObjectByType<Enemy>() == null)
        {
            GameComplete();
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        secondCam.SetActive(true);
        Destroy(FindAnyObjectByType<playerMovement>().gameObject);
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameComplete()
    {
        levelCompleteScreen.SetActive(true);
        secondCam.SetActive(true);
        Destroy(FindAnyObjectByType<playerMovement>().gameObject);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void NextLvl()
    {
        SceneManager.LoadScene("Level "+ SceneManager.GetActiveScene().buildIndex+1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
