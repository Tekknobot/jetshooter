using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 100;

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
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        }        

		playerTarget player = other.GetComponent<playerTarget>();
		if (player != null)
		{
			player.PlayerTakeDamage(damage);
		}             
    }    
}
