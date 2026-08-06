using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float _health;
    public Slider healthBar;
    public Gradient healthGrad;
    public Image fill;
    public Text healthTxt;
    public GameObject _gameOverScreen;
    public GameObject _gameWinScreen;
    bool gameOver;

    private void Start()
    {
        healthTxt.text = _health.ToString() + "%";
        healthBar.maxValue = _health;
        healthBar.value = _health;
        fill.color = healthGrad.Evaluate(1f);
        gameOver = false;
    }

    private void Update()
    {
        healthTxt.text = _health.ToString() + "%";
        healthBar.value = _health;
        fill.color = healthGrad.Evaluate(healthBar.normalizedValue);

        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Retry();
        }

        if (FindAnyObjectByType<Enemy>() == null)
        {
            _gameWinScreen.SetActive(true);
            gameOver = true;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        _gameOverScreen.SetActive(true);
        gameOver = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
