﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMovement : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 0;

    public GameObject sfx;
    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "player") {
            Instantiate(sfx, transform.position, Quaternion.identity);
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } 

		playerTarget player = other.GetComponent<playerTarget>();
		if (player != null)
		{
			//player.PlayerTakeDamage(damage);
		}             
    }    
}
