using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider fill;

    public void SetHealth(int health)
    {
        fill.value = health;
    }

    public void setMaxHealth(int maxHealth)
    {
        fill.maxValue = maxHealth;
        fill.value = maxHealth;
    }
}
