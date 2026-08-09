using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject HealthPowerUp;

    //public GameObject playerCam = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = playerCam.transform.rotation;
        //transform.rotation = Quaternion.Euler(0f, -transform.rotation.eulerAngles.y, 0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.Heal(20);
        }
        Destroy(HealthPowerUp, 0);
    }
}
