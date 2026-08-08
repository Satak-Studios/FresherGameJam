using UnityEngine;


public class bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
        if(ph != null){
            ph.TakeDamage(10);
        }
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        //Destroy(gameObject,3);
        //The Time to be quicker
        Destroy(gameObject,1);
    }
}
