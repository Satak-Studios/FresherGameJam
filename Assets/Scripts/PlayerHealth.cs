using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public health_bar playerHP;
    [SerializeField] TextMeshProUGUI healthText;

    public GameManager gameManager;
    public bool isTutu = false;
    public GameObject tutuScreen = null;

    void Start()
    {
        playerHP.setMaxHealth(health);
        healthText.text = health.ToString();
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (isTutu)
            {
                tutuScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                gameManager.GameOver();
            }
        }
        else
        {
            playerHP.SetHealth(health);
            healthText.text = health.ToString();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        playerHP.SetHealth(health);
        healthText.text = health.ToString();
    }

    public void Heal(int amt)
    {
        health = health + amt;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
