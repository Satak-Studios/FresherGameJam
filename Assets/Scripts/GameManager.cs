using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    bool gameCompleted = false;

    public GameObject secondCam;
    public Text scoreText;
    public int _score = 0;

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
            gameCompleted = true;
        }
        else
        {
            gameCompleted = false;
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
        gameCompleted = true;
        if (!gameCompleted)
        {
            Destroy(FindAnyObjectByType<playerMovement>().gameObject);
        }
        Cursor.lockState = CursorLockMode.None;
        //This is actual code and will be done after finalising score mechanics
        //scoreText.text = "Score : " + _score.ToString();
        scoreText.text = "Score : 00";
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
        SceneManager.LoadScene("Level "+ (SceneManager.GetActiveScene().buildIndex+1));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
