using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) Debug.Log("Player Died, Game Over");
        Debug.Log("Player took damage and the current health is " + _health);
    }
}
