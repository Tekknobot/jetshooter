using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossTarget : MonoBehaviour
{
    public HealthBar healthBar; 
    public GameObject bossBar;

    public int maxHealth = 100;
	public int currentHealth;
    
    public GameObject explosionPrefab; 
	public GameObject explosionEmitter;

    public GameObject primaryTurret;

    public float pieceCount = 12f;

    public GameObject[] oscillators;   

    bool explosionTaskStarted = false; 

    void Start() {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

        GetComponent<ObjectOscillator>().enabled = true;        
        //GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update() {
        if(transform.position.y <= -15) {
            Destroy(this.gameObject);
        }
    }

    public void BossTakeDamage (int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f && explosionTaskStarted == false)
        {
            InstantiateCircle();
            explosionTaskStarted = true;
            bossBar.SetActive(false);
            primaryTurret.SetActive(false);
        }
    }

    void InstantiateCircle () 
    {
        StartCoroutine(ExplosionTask());
    }

    void GetObject()
    {
        GetComponent<ObjectOscillator>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void Death()
    {       
        GetComponent<LootDrop>().LootChance();
        Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }

    IEnumerator ExplosionTask() {
        GetObject();
        for (int i = 0; i < pieceCount; i++)
        {
            /* Distance around the circle */  
            var radians = 2 * Mathf.PI / pieceCount * i;

            /* Get the vector direction */ 
            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector3 (horizontal, 0, vertical);

            /* Get the spawn position */ 
            var spawnPos = transform.position + spawnDir * 3f; // Radius is just the distance away from the point
            
            Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            GetComponent<ShakeBehavior>().enabled = true;
            this.gameObject.SendMessage("TriggerShake", SendMessageOptions.RequireReceiver);
            yield return new WaitForSeconds(0.2f);
        }    
        Death();    
    }
}
