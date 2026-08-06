using UnityEngine;


public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
        if(ph != null){
            ph.TakeDamage(10);
        }
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        Destroy(gameObject,3);
    }
}
