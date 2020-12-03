using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerTarget : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;

    public GameObject explosionPrefab; 
	public GameObject explosionEmitter; 

	public HealthBar healthBar;   

    public AudioClip hit_sfx;
    private AudioSource source;

    public GameObject girl;
    public GameObject alien;
    public GameObject robot;  

    public bool girlCalled = false;
    public bool alienCalled = false;
    public bool robotCalled = false;

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

        if(other.tag == "pickup" && girlCalled == false) {      
            girl.GetComponent<SmoothFollow>().enabled = true;  
            girl.GetComponent<NPC>().enabled = true;   
            girlCalled = true; 
        }

        if(other.tag == "pickup2" && girlCalled == true) {      
            robot.GetComponent<SmoothFollow>().enabled = true;  
            robot.GetComponent<NPC>().enabled = true; 
            robotCalled = true;   
        }

        if(other.tag == "pickup3" && girlCalled == true && robotCalled == true) {      
            alien.GetComponent<SmoothFollow>().enabled = true;  
            alien.GetComponent<NPC>().enabled = true;    
        }
    }  

    void Death()
    {        
        Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity); 
        SceneManager.LoadScene("SampleScene");
        Destroy(gameObject);
    }
}
