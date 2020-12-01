using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public GameObject explosionPrefab; 
	public GameObject explosionEmitter;
    public GameObject maincamera;

    public Sprite[] Portraits;
    public Image Portrait;

    public Animator animator;
    public int currentPic;  

    public Text pilotName;
    public Text pilotText;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {       
        GetComponent<LootDrop>().LootChance();
         
        Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity); 
        maincamera.SendMessage("TriggerShake");
        Destroy(gameObject);

        if (animator.GetBool("IsOpen") == false) {
            if(Random.Range(0f, 1f) <= m_dialogueChance ) {        
                GetComponent<DialogueTrigger>().TriggerDialogue();
            
                //portrait change
                currentPic = Random.Range (0, Portraits.Length);
                Portrait.sprite = Portraits[currentPic]; 
                
                //pilot name change 
                if (Portrait.sprite.name == "alien-portrait 0") {
                    pilotName.text = "Mr. X";
                    pilotText.text = "Billions of lightyears and you had to run into mine.";
                }  
                if (Portrait.sprite.name == "girl-portrait 0") {
                    pilotName.text = "Venn Detta";
                    pilotText.text = "See you in hellspace Cowboy!";
                }         
                if (Portrait.sprite.name == "pilot-portrait 0") {
                    pilotName.text = "Zedd Mann";
                    pilotText.text = "That's right Man! I am dangerous.";
                } 
                if (Portrait.sprite.name == "robot-portrait 0") {
                    pilotName.text = "P-3P0";
                    pilotText.text = "You can land a jumbo fucking jet in there.";
                }  
            }
        }
    }
    const float m_dialogueChance = 0.2f / 10f;     // Set odds here - e.g. 1 in 10 chance
}
