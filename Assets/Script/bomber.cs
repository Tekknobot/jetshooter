using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject guardLeft;
    public GameObject gaurdRight;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SmoothFollow>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;                    
    }

    // Update is called once per frame
    void Update()
    {
        if (guardLeft == null && gaurdRight == null) {
            primaryWeapon.SetActive(true);
        }

        if (gameObject.GetComponent<bossTarget>().currentHealth <= 0f) {
            primaryWeapon.SetActive(false);
        }
    }
}
