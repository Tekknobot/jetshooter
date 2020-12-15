using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pharaoh_mini : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject bomber_miniPos;

    public GameObject bullet_0;
    public GameObject bullet_45;
    public GameObject bullet_90;
    public GameObject bullet_135;
    public GameObject bullet_180;
    public GameObject bullet_225;
    public GameObject bullet_270;
    public GameObject bullet_315;

    public float fireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SmoothFollow>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;                    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "triggerBox") {
            primaryWeapon.SetActive(true);
            StartCoroutine(SwitchProjectile());
        }
    }

    IEnumerator SwitchProjectile() {
        yield return new WaitForSeconds(fireRate);
        primaryWeapon.GetComponent<Turrets>().bullet = bullet_135;
        yield return new WaitForSeconds(fireRate);
        primaryWeapon.GetComponent<Turrets>().bullet = bullet_180;
        yield return new WaitForSeconds(fireRate);
        primaryWeapon.GetComponent<Turrets>().bullet = bullet_225;   
        StartCoroutine(SwitchProjectile());     
    }
}
