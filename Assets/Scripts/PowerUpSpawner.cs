using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public int spawnRangeX = 0;
    public int spawnRangeZ = 0;
    public GameObject mySphere;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (FindAnyObjectByType<PlayerHealth>() == null)
        {
            Invoke(nameof(SpawnSphere), 1f);
        }
    }

    void SpawnSphere()
    {
        Debug.Log("Spawning PowerUp");
        int spawnPointX = Random.Range(-spawnRangeX, spawnRangeX);
        int spawnPointZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 spawnPosition = new Vector3(spawnPointX, 11.6f, spawnPointZ);
        Instantiate(mySphere, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRangeX);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRangeZ);
    }
}
