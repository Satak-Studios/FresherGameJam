using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    bool gameCompleted = false;
    public bool isBoss = false;

    public GameObject secondCam;

    public bool isFirstWave = true;
    public bool theEnd = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindAnyObjectByType<Enemy>() == null && !isBoss)
        {
            GameComplete();
            gameCompleted = true;
        }
        else if(!isBoss && FindAnyObjectByType<Enemy>() != null)
        {
            gameCompleted = false;
        }

        if (isBoss && FindAnyObjectByType<MiniBoss>() == null && FindAnyObjectByType<Enemy>() == null && theEnd)
        {
            gameCompleted = true;
            GameOver();
        }
        else if (isBoss && FindAnyObjectByType<Boss>() != null || FindAnyObjectByType<Enemy>() != null)
        {
            gameCompleted = false;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        secondCam.SetActive(true);
        if (FindAnyObjectByType<playerMovement>() != null)
        {
            Destroy(FindAnyObjectByType<playerMovement>().gameObject);
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameComplete()
    {
        levelCompleteScreen.SetActive(true);
        secondCam.SetActive(true);
        gameCompleted = true;
        if (!gameCompleted)
        {
            Destroy(FindAnyObjectByType<playerMovement>().gameObject);
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void NextLvl()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            int levelCompleted = PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt("level", levelCompleted);
            Debug.Log("Level Completed and levels completed are " + levelCompleted);
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
        }
        SceneManager.LoadScene("level "+ (SceneManager.GetActiveScene().buildIndex+1));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
