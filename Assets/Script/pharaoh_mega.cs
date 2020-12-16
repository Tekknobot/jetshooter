using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pharaoh_mega : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject turret;

    public GameObject crit_0;
    public GameObject crit_1;
    public GameObject crit_2;
    public GameObject crit_3;
    public GameObject crit_4;
    public GameObject crit_5;
    public GameObject crit_6;
    public GameObject crit_7;
    public GameObject crit_8;
    public GameObject crit_9;
    public GameObject crit_10;
    public GameObject crit_11;
    public GameObject crit_12;
    public GameObject crit_13;    

    // Start is called before the first frame update
    void Start()
    {
                   
    }

    // Update is called once per frame
    void Update()
    {
        if (turret == null) {
            gameObject.GetComponent<SmoothFollow>().enabled = true;
            //gameObject.GetComponent<BoxCollider2D>().enabled = true;             
        }

        if (crit_0 == null && crit_1 == null && crit_2 == null && crit_3 == null && crit_4 == null && crit_5 == null && crit_6 == null && 
            crit_7 == null && crit_8 == null && crit_9 == null && crit_10 == null && crit_11 == null && crit_12 == null && crit_13 == null) {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;             
        }        

        if (gameObject.GetComponent<bossTarget>().currentHealth <= 0f) {
            primaryWeapon.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "triggerBox") {
            primaryWeapon.SetActive(true);
        }
    }    
}
