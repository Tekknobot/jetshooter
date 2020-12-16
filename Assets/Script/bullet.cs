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
        //rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "A0") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        } 

        if(other.tag == "A45") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        } 

        if(other.tag == "A90") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        } 

        if(other.tag == "A135") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        }         

        if(other.tag == "A180") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        } 

        if(other.tag == "A225") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        } 

        if(other.tag == "A270") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        } 

        if(other.tag == "A360") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        }      

        if(other.tag == "gundam") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        }       

        if(other.tag == "Boss") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
        }             

        if(other.tag == "Boss_bullets") {
            if (gameObject.tag == "bullet") {
                gameObject.SetActive(false);
            } else {
                Destroy(gameObject);
            }
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

		bulletTarget bullet_mini = other.GetComponent<bulletTarget>();
		if (bullet_mini != null)
		{
			bullet_mini.bulletTakeDamage(damage);
		}      

		TargetCrit crit = other.GetComponent<TargetCrit>();
		if (crit != null)
		{
			crit.critTakeDamage(damage);
		}              
    }     

    void OnBecameInvisible() {
        if (gameObject.tag == "bullet") {
            gameObject.SetActive(false);
        } else {
            Destroy(gameObject);
        }
    }     
}
