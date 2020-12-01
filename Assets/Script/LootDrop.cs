using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject lootEmitter;
    public GameObject health;

    public void LootChance()
    {
        if(Random.Range(0f, 1f) <= m_healthChance )
        {
            // spawn a dropped item
            Instantiate(health, transform.position, Quaternion.identity);
        }                             
    }

    const float m_healthChance = 1f / 10f;             // Set odds here - e.g. 1 in 10 chance     
}
