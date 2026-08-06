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

            if (hitCollider.GetComponent<Enemy>() != null)
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
        if (_health <= 0)
        {
            Blast();
        }
    }

    void Blast()
    {
	    _blast.Play();
        CauseDamage();
	    Destroy(gameObject, 0.97f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
