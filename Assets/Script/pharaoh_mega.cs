using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pharaoh_mega : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject turret;

    public GameObject bossBar;
    bool bossHealthSet = false;

    public GameObject crit_0;
    public GameObject crit_1;
    public GameObject crit_2;
    public GameObject crit_3;
    public GameObject crit_4;
    public GameObject crit_5; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ObjectOscillator>().enabled = false;
        gameObject.GetComponent<SmoothFollow>().enabled = true;

        crit_0.GetComponent<Turrets>().enabled = false;
        crit_1.GetComponent<Turrets>().enabled = false;
        crit_2.GetComponent<Turrets>().enabled = false;
        crit_3.GetComponent<Turrets>().enabled = false;
        crit_4.GetComponent<Turrets>().enabled = false;
        crit_5.GetComponent<ObjectEmitter>().enabled = false;

        StartCoroutine(BeginSequences());               
    }

    // Update is called once per frame
    void Update()
    {
        if (turret == null) {
            gameObject.GetComponent<SmoothFollow>().enabled = true;
            bossBar.SetActive(true);   
            if (bossHealthSet == false) {
                bossBar.GetComponent<HealthBar>().SetMaxHealth(gameObject.GetComponent<bossTarget>().maxHealth); 
                bossHealthSet = true;   
            }            
        }

        if (crit_0 == null && crit_1 == null && crit_2 == null && crit_3 == null && crit_4 == null && crit_5 == null) {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;    
            gameObject.GetComponent<ObjectOscillator>().enabled = true;          
        }        

        if (gameObject.GetComponent<bossTarget>().currentHealth <= 0f) {
            primaryWeapon.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "triggerBox") {
            primaryWeapon.SetActive(true);
        }
    }    

    IEnumerator BeginSequences() {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SmoothFollow>().enabled = false;
        primaryWeapon.SetActive(false);
        if (crit_5 != null) {
            crit_5.GetComponent<ObjectEmitter>().enabled = false;
        }
        if (crit_0 != null) {
            crit_0.GetComponent<Turrets>().enabled = true;
        }        

        yield return new WaitForSeconds(1);
        if (crit_0 != null) {        
            crit_0.GetComponent<Turrets>().enabled = false;
        }
        if (crit_1 != null) {        
            crit_1.GetComponent<Turrets>().enabled = true;
        }
        if (crit_3 != null) {        
            crit_3.GetComponent<Turrets>().enabled = true;
        }                    

        yield return new WaitForSeconds(1);
        if (crit_1 != null) {        
            crit_1.GetComponent<Turrets>().enabled = false;
        }      
        if (crit_3 != null) {        
            crit_3.GetComponent<Turrets>().enabled = false;
        }    
        if (crit_2 != null) {        
            crit_2.GetComponent<Turrets>().enabled = true;
        }    
        if (crit_4 != null) {        
            crit_4.GetComponent<Turrets>().enabled = true; 
        }                               

        yield return new WaitForSeconds(1);
        if (crit_2 != null) {        
            crit_2.GetComponent<Turrets>().enabled = false; 
        }   
        if (crit_4 != null) {        
            crit_4.GetComponent<Turrets>().enabled = false;
        } 
        if (crit_5 != null) {        
            crit_5.GetComponent<ObjectEmitter>().enabled = true; 
        }      

        yield return new WaitForSeconds(1);
        if (crit_5 != null) {        
            crit_5.GetComponent<ObjectEmitter>().enabled = false; 
        }
        gameObject.GetComponent<ObjectOscillator>().enabled = true;
        primaryWeapon.SetActive(true);

        yield return new WaitForSeconds(5); 
        gameObject.GetComponent<SmoothFollow>().enabled = true;
        gameObject.GetComponent<ObjectOscillator>().enabled = false;       
        primaryWeapon.SetActive(false);

        yield return new WaitForSeconds(5);
        StartCoroutine(BeginSequences());                  
    }
}
