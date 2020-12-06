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

    public int pickHealthValue;

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

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    public void PlayerTakeDamage (int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        GetComponent<AudioSource>().clip = hit_sfx;
        source.Play();  

        if(girlCalled == true) {
            girl.GetComponent<SmoothFollow>().enabled = false;  
            girl.GetComponent<SmoothFallback>().enabled = true;
            girl.GetComponent<NPC>().enabled = false;   
            girlCalled = false;
        }
        if(robotCalled == true) {
            robot.GetComponent<SmoothFollow>().enabled = false;  
            robot.GetComponent<SmoothFallback>().enabled = true;
            robot.GetComponent<NPC>().enabled = false;   
            robotCalled = false;
        }    
        if(alienCalled == true) {
            alien.GetComponent<SmoothFollow>().enabled = false;  
            alien.GetComponent<SmoothFallback>().enabled = true;
            alien.GetComponent<NPC>().enabled = false;
            alienCalled = false;                      
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "gundam" || other.tag == "Boss") {   
            currentHealth = 0;      
        }  

        if(other.tag == "health") {   
            currentHealth += pickHealthValue;    
            healthBar.SetHealth(currentHealth);      
        }   

        if(other.tag == "pickup" && girlCalled == false && robotCalled == false && alienCalled == false) {      
            girl.GetComponent<SmoothFollow>().enabled = true;  
            girl.GetComponent<NPC>().enabled = true; 
            girl.GetComponent<SmoothFallback>().enabled = false;  
            girlCalled = true; 
        }

        if(other.tag == "pickup2" && girlCalled == true && robotCalled == false && alienCalled == false) {      
            robot.GetComponent<SmoothFollow>().enabled = true;  
            robot.GetComponent<NPC>().enabled = true; 
            robot.GetComponent<SmoothFallback>().enabled = false;
            robotCalled = true;   
            girlCalled = true;
        }

        if(other.tag == "pickup3" && girlCalled == true && robotCalled == true && alienCalled == false) {      
            alien.GetComponent<SmoothFollow>().enabled = true;  
            alien.GetComponent<NPC>().enabled = true;  
            alien.GetComponent<SmoothFallback>().enabled = false;
            alienCalled = true;  
            robotCalled = true;   
            girlCalled = true;            
        }      
    }  

    void Death()
    {        
        Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity); 
        SceneManager.LoadScene("SampleScene");
        Destroy(gameObject);
    }
}
