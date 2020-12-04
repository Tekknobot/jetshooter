using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "gundam") {
            Destroy(this.gameObject);
        } 

		Target enemy = other.GetComponent<Target>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}     

		bossTarget boss = other.GetComponent<bossTarget>();
		if (boss != null)
		{
			boss.BossTakeDamage(damage);
		} 
    }     

    void OnBecameInvisible() {
        Destroy(gameObject);
    }     
}
