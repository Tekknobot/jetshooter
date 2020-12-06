using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject lootEmitter;

    public GameObject health;
    public GameObject star;
    public GameObject pickup;
    public GameObject pickup2;
    public GameObject pickup3;

    public void LootChance()
    {
        if(Random.Range(0f, 1f) <= m_healthChance ) {
            // spawn a dropped item
            Instantiate(health, transform.position, Quaternion.identity);
        }     

        if(Random.Range(0f, 1f) <= m_starChance ) {
            // spawn a dropped item
            Instantiate(star, transform.position, Quaternion.identity);
        }  

        if(Random.Range(0f, 1f) <= m_pickUpChance) {
            // spawn a dropped item
            Instantiate(pickup, transform.position, Quaternion.identity);
        }   

        if(Random.Range(0f, 1f) <= m_pickUpChance2) {
            // spawn a dropped item
            Instantiate(pickup2, transform.position, Quaternion.identity);
        }

        if(Random.Range(0f, 1f) <= m_pickUpChance3) {
            // spawn a dropped item
            Instantiate(pickup3, transform.position, Quaternion.identity);
        }
    }

    const float m_healthChance = 0.5f / 10f;             // Set odds here - e.g. 1 in 10 chance   
    const float m_starChance = 0.5f / 10f;
    const float m_pickUpChance = 0.5f / 10f;  
    const float m_pickUpChance2 = 0.5f / 10f;
    const float m_pickUpChance3 = 0.5f / 10f;
}
