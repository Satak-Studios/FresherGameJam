using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 10f;

    public Camera fpsCamera;
    public ParticleSystem ps;
    // Update is called once per frame
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot()
    {
        ps.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out hit))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
