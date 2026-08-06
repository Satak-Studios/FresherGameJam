using UnityEngine;


public class bullet : MonoBehaviour
{
    public float enemyBulletDamage = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(enemyBulletDamage);
            }
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            Destroy(gameObject, 1f);
        }
    }
}
