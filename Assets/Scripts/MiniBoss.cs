using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MiniBoss : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public float offset;

    public LayerMask whatIsGround, whatIsPlayer;
    public float health_max = 30f;
    //public float respawn_prob = 0.2f;
    //public ParticleSystem respawn_particle;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    //Attacking
    public float timeBetweenAttacks;
    public float attack_offsets = 1f;
    bool alreadyAttacked;
    public GameObject projectile;
    public float projectile_speedX;
    public float projectile_speedY;

    public float thickify_probability;
    public float thicknessFactor;

    public Transform Shooter;
    public AudioClip hurt_sound;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float health;
    public Slider healthBar;

    //Daughter offspring
    public MiniBoss[] miniBoss;

    //Thy Boss Hath Arrived
    public GameObject _boss;
    public ParticleSystem explosionpParticle;

    public dialogue D;

    void Start()
    {
        health = health_max;
        healthBar.maxValue = health_max;
        explosionpParticle.Stop();
    }
    private void FixedUpdate()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (!playerInSightRange && playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        healthBar.value = health;
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Debug.Log("chasing");
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 lookat = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookat);
        transform.rotation *= Quaternion.Euler(0, offset, 0);

        if (!alreadyAttacked)
        {
            GameObject bullet = Instantiate(projectile, Shooter.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (UnityEngine.Random.Range(0f, 1f) < thickify_probability)
            {
                bullet.transform.localScale += new Vector3(thicknessFactor, 0F, 0f);
            }

            rb.AddForce(transform.forward * projectile_speedX + transform.right * projectile_speedY, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks + UnityEngine.Random.Range(0, attack_offsets));
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        SFXManager.instance.PlaySFXClip(hurt_sound, transform, 1f);
        if (health <= 0)
        {
            explosionpParticle.Play();
            FindAnyObjectByType<ScreenShake>().StartShake(0.6f, 0.5f);
            Invoke(nameof(DestroyEnemy), 0.2f);
        }
    }
    private void DestroyEnemy()
    {
        Debug.Log("hello1");
        D.gameObject.SetActive(true);

        healthBar.gameObject.SetActive(false);
        _boss.SetActive(false);
        int totalMinis = FindObjectsByType<MiniBoss>().Length;
        Debug.Log("Total Minis : " + totalMinis);
        if (totalMinis == 1)
        {
            Invoke(nameof(EndGame),5f);
        }

    }

    void EndGame()
    {
        GameManager _gm = FindAnyObjectByType<GameManager>();
        _gm.theEnd = true;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
