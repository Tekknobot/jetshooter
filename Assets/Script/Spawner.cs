using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
 
    public float spawnTime;        // The amount of time between each spawn.
    public float spawnDelay;       // The amount of time before spawning starts.
    public GameObject enemy;
 
    public int maxDistance;
    public Transform spawnTarget;
    public Transform playerTransform;
 
    void Awake()
    {

    }
 
    void Start()
    {
        StartCoroutine(SpawnTimeDelay());
    }
 
    IEnumerator SpawnTimeDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        
        while (true)
        {
            if (Vector2.Distance(spawnTarget.position, playerTransform.position) < maxDistance)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
 
            if (Vector2.Distance(spawnTarget.position, playerTransform.position) > maxDistance)
            {
                yield return null;
            }                
        }
    }
}
