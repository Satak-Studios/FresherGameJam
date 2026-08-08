using TMPro;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public health_bar playerHP;
    [SerializeField] TextMeshProUGUI healthText;

    public GameManager gameManager;

    void Start()
    {
        playerHP.setMaxHealth(health);
        healthText.text = health.ToString();
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        playerHP.SetHealth(health);
        healthText.text = health.ToString();
    }
}
