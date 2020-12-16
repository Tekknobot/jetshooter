using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharaohTurret : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject guardLeft;
    public GameObject gaurdMiddle;
    public GameObject gaurdRight;
    public GameObject bomber;
    public GameObject bomberPrimaryWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (guardLeft == null && gaurdMiddle == null && gaurdRight == null && bomberPrimaryWeapon.activeSelf == true) {
            gameObject.GetComponent<SmoothFollow>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            primaryWeapon.SetActive(true);
        }

        if (guardLeft == null && gaurdRight == null && bomber == null) {
            gameObject.GetComponent<ObjectOscillator>().enabled = true;
            gameObject.GetComponent<ObjectOscillator>().speedMult = 5f;
            gameObject.GetComponent<ObjectOscillator>().rangeMult = 4f;
        }        
    }
}
