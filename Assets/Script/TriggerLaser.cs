﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLaser : MonoBehaviour
{
    public GameObject player;
    public float Radius;
    public GameObject laser;
    public float laserDuration = 10;
    public float timeRemaining = 5;
    
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
 
        if (dist < Radius)
        {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }    
            else {
                StartCoroutine(TriggerEnemyLaser());
                timeRemaining = 5;
            }      
        }    
    }

    IEnumerator TriggerEnemyLaser() {
        laser.SetActive(true);
        yield return new WaitForSeconds(laserDuration);
        laser.SetActive(false);
    }
}
