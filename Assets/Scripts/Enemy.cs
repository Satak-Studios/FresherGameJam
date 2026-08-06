using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public float offset;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public float projectile_speedX = 30f;
    public float projectile_speedY = 5f;

    public Transform Shooter;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Health Bar => same as player script
    public float _health;
    public Slider healthBar;
    public Gradient healthGrad;
    public Image fill;
    public Text healthTxt;

    public Camera playerCam;
    bool isAttacking = false;

    private void Start()
    {
        healthTxt.text = _health.ToString() + "%";
        healthBar.maxValue = _health;
        healthBar.value = _health;
        fill.color = healthGrad.Evaluate(1f);
    }

    private void FixedUpdate()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Update()
    {
        /*if (isAttacking)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
            {
                PlayerHealth _player = hit.transform.GetComponent<PlayerHealth>();
                if (_player != null)
                {
                    _player.TakeDamage(20);
                }
            }
        }*/

        healthTxt.text = _health.ToString() + "%";
        healthBar.value = _health;
        fill.color = healthGrad.Evaluate(healthBar.normalizedValue);
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
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        isAttacking = true;
        agent.SetDestination(transform.position);

        Vector3 aim = new Vector3(player.position.x,transform.position.y,player.position.z);
        transform.LookAt(aim);
        transform.rotation *= Quaternion.Euler(0,offset,0);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, Shooter.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * projectile_speedX + transform.right*projectile_speedY, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            isAttacking = false;
        } 
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
        healthTxt.text = _health.ToString() + "%";
        healthBar.value = _health;
        fill.color = healthGrad.Evaluate(healthBar.normalizedValue);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
