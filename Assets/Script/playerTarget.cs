using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTarget : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;

    public GameObject explosionPrefab; 
	public GameObject explosionEmitter; 

	public HealthBar healthBar;   

    public AudioClip hit_sfx;
    private AudioSource source;     

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

        source = GetComponent<AudioSource>();
    }

    void Update() {
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public void PlayerTakeDamage (int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        GetComponent<AudioSource>().clip = hit_sfx;
        source.Play();  

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "health") {   
            currentHealth += 10;    
            healthBar.SetHealth(currentHealth);      
        }           
    }  

    void Death()
    {        
        Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}
