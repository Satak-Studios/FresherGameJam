using TMPro;
using UnityEngine;
using TMPro;

public class Barrel : MonoBehaviour
{
    public int _health;
    public float attackRange;
    public ParticleSystem _blast;

    public float damageRadius = 5f;
    public int damageAmount = 25;
    public LayerMask damageLayer;

    public bool isInverted = false;
    public float healProb = 0.9f;

    void CauseDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRadius, damageLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the object has a damage receiver script
            if (hitCollider.GetComponent<PlayerHealth>() != null)
            {
                hitCollider.GetComponent<PlayerHealth>().TakeDamage(damageAmount);        
            }

            if (hitCollider.GetComponent<Enemy>() != null && !isInverted)
            {
                hitCollider.GetComponent<Enemy>().TakeDamage(damageAmount);
            }
        }
    }

    void Start()
    {
        _blast.Stop();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0 && Random.Range(0f, 1f) < healProb)
        {
            isInverted = true;
            InvertBlast();
        }
        else if (_health <= 0 && !isInverted)
        {
            Blast();
        }
        Debug.Log("The barrel health is " + _health);
    }

    void Blast()
    {
	    _blast.Play();
        CauseDamage();
	    Destroy(gameObject, 0.97f);
        Debug.Log("Blast!");
    }

    void InvertBlast()
    {
        _blast.Play();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRadius, damageLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the object has a damage receiver script
            if (hitCollider.GetComponent<PlayerHealth>() != null)
            {
                hitCollider.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
            }

            if (hitCollider.GetComponent<Enemy>() != null)
            {
                hitCollider.GetComponent<Enemy>().Heal(20f);
                hitCollider.GetComponent<Enemy>().respawn_particle.Play();
            }
        }
        //Debug.Log("Healed!");
        Destroy(gameObject, 0.97f);
        isInverted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
