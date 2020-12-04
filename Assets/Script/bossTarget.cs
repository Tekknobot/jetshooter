using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossTarget : MonoBehaviour
{
    public HealthBar healthBar; 

    public int maxHealth = 100;
	public int currentHealth;
    
    public GameObject explosionPrefab; 
	public GameObject explosionEmitter;

    void Start() {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
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
        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    void Death()
    {       
        GetComponent<LootDrop>().LootChance();
         
        Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity); 
        GameObject.Find("Boss bar").SetActive(false);
        Destroy(gameObject);
    }
}
