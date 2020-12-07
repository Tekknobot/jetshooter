using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber_mini : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject bomber_miniPos;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SmoothFollow>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;                    
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "triggerBox") {
            primaryWeapon.SetActive(true);
        }
    }
}
