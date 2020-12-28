using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuttle : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject guardLeft;
    public GameObject guardMiddle;
    public GameObject guardRight;
    public GameObject guardBottom;

    public GameObject secondaryGuards;

    // Start is called before the first frame update
    void Start()
    {
                   
    }

    // Update is called once per frame
    void Update()
    {
        if (guardLeft == null && guardMiddle == null && guardRight == null && guardBottom == null) {
            gameObject.GetComponent<SmoothFollow>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;             
        }

        if (gameObject.GetComponent<bossTarget>().currentHealth <= 0f) {
            primaryWeapon.SetActive(false);
            secondaryGuards.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "triggerBox") {
            primaryWeapon.SetActive(true);
        }
    }    
}
