using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public GameObject explosionPrefab; 
	//public GameObject explosionEmitter;

    public Sprite[] Portraits;
    public Image Portrait;

    public Animator animator;
    public int currentPic;  

    public Text pilotName;
    public Text pilotText;

    public List<string> DialogueList = new List<string>();

    public GameObject[] emitters;
    

    void Awake() {
                
    }

    void Start() {
        Portrait = GameObject.FindGameObjectWithTag("Portrait").GetComponent<UnityEngine.UI.Image>();
        animator = GameObject.FindGameObjectWithTag("DialogueBox").GetComponent<UnityEngine.Animator>();
        pilotName = GameObject.FindGameObjectWithTag("PilotName").GetComponent<UnityEngine.UI.Text>();
        pilotText = GameObject.FindGameObjectWithTag("PilotDialogue").GetComponent<UnityEngine.UI.Text>();

        emitters = GameObject.FindGameObjectsWithTag("Hell_Emitter");
    }

    public void TakeDamage (float amount) {
        health -= amount;
        if (health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {       
        GetComponent<LootDrop>().LootChance();
         
        Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);         
        Destroy(this.gameObject);

        if (animator.GetBool("IsOpen") == false) {
            if(Random.Range(0f, 1f) <= m_dialogueChance ) {        
                GetComponent<DialogueTrigger>().TriggerDialogue();
            
                //portrait change
                currentPic = Random.Range (0, Portraits.Length);
                Portrait.sprite = Portraits[currentPic]; 
                
                //pilot name change 
                if (Portrait.sprite.name == "alien-portrait 0") {
                    pilotName.text = "Mr. X";
                    pilotText.text = DialogueList[Random.Range(0, DialogueList.Count)];
                }  
                if (Portrait.sprite.name == "girl-portrait 0") {
                    pilotName.text = "Venn Detta";
                    pilotText.text = DialogueList[Random.Range(0, DialogueList.Count)];
                }         
                if (Portrait.sprite.name == "pilot-portrait 0") {
                    pilotName.text = "Zedd Mann";
                    pilotText.text = DialogueList[Random.Range(0, DialogueList.Count)];
                } 
                if (Portrait.sprite.name == "robot-portrait 0") {
                    pilotName.text = "P-3P0";
                    pilotText.text = DialogueList[Random.Range(0, DialogueList.Count)];
                }  
            }
        }
    }
    const float m_dialogueChance = 0.05f / 10f;     // Set odds here - e.g. 1 in 10 chance
}