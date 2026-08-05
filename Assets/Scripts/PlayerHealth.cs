using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) Debug.Log("Player Died, Game Over");
        Debug.Log("Player took damage and the current health is " + _health);
    }
}
