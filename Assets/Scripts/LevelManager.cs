using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelsCompleted;
    public Text toolTip;

    public Button[] levelSprits;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelsCompleted = PlayerPrefs.GetInt("level");
    }

    // Update is called once per frame
    void Update()
    { 
        for (int i = 1; i < levelSprits.Length; i++)
        {
            if (i < levelsCompleted)
            {
                levelSprits[i].interactable = true;
            }
            else
            {
                levelSprits[i].interactable = false;
            }
        }

        if (levelsCompleted == 2)
        {
            toolTip.gameObject.SetActive(true);
        }
        else if (levelsCompleted == 4)
        {
            toolTip.gameObject.SetActive(true);
            toolTip.text = "Game Completed!";
        }
        else
        {
            toolTip.gameObject.SetActive(false);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene("level " + index);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

}
