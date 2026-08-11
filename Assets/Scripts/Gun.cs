using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public int barrelDamage = 10;
    public float range = 10f;
    public AudioClip gun_sound;

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
        SFXManager.instance.PlaySFXClip(gun_sound,transform,1f);
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out hit))
        {
            Boss _boss = hit.transform.GetComponent<Boss>();
            MiniBoss _mBoss = hit.transform.GetComponent<MiniBoss>();
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            Barrel barrel = hit.transform.GetComponent<Barrel>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
            if(_boss != null)
            {
                _boss.TakeDamage(damage);
            }

            if (_mBoss != null)
            {
                _mBoss.TakeDamage(damage);
            }

            if (barrel != null)
            {
                barrel.TakeDamage(barrelDamage);
                //Debug.Log("Barrel taking damage!");
            }
        }
    }
}
