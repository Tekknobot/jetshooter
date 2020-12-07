using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletTarget : MonoBehaviour
{
    public float health = 30f;
    public GameObject explosionPrefab;

    void Awake() {
                
    }

    void Start() {

    }   

    public void bulletTakeDamage (float amount)
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
        Instantiate(explosionPrefab, this.transform.position, Quaternion.identity); 
        gameObject.SetActive(false);
    }
}