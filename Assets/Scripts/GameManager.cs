using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    public GameObject gameCompleteScreen = null;
    bool gameCompleted = false;
    public bool isBoss;

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

        if (isBoss && FindAnyObjectByType<Boss>() == null && FindAnyObjectByType<Enemy>() == null && FindAnyObjectByType<MiniBoss>() == null && theEnd)
        {
            Debug.Log("hey!");
            gameCompleted = true;
            GameComplete();
        }
        else if (isBoss && (FindAnyObjectByType<MiniBoss>() != null || FindAnyObjectByType<Enemy>() != null))
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
        if (!isBoss)
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
        else
        {
            gameCompleteScreen.SetActive(true);
            secondCam.SetActive(true);
            gameCompleted = true;
            if (!gameCompleted)
            {
                Destroy(FindAnyObjectByType<playerMovement>().gameObject);
            }
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void NextLvl()
    {
        if (PlayerPrefs.GetInt("level") > 0)
        {
            int levelCompleted = PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt("level", levelCompleted+1);
            Debug.Log("Level Completed and levels completed are " + levelCompleted);
        }
        else if(PlayerPrefs.GetInt("level") <= 0)
        {
            PlayerPrefs.SetInt("level", 1);
        }
        SceneManager.LoadScene("level "+ (SceneManager.GetActiveScene().buildIndex+1));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameCompleted()
    {
        SceneManager.LoadScene("LevelManager");
    }
}
