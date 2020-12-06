using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float roationSpeed = 2f;
    public float maxRotation = 45f;  

    public GameObject projectile;  
    public GameObject leftgun;
    public GameObject rightgun;

    float gunTimer;
    public float gunDelay;
    bool canshoot = false;

    public GameObject shaker;
    public Camera mainCamera;    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //tilt
        transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * roationSpeed), 0f);

        if (Input.GetMouseButtonUp(0)) {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }  
        if (Input.GetMouseButton(0) && !canshoot) { 
            StartCoroutine(FireShot());
        }

        mainCamera.GetComponent<BackgroundColorLerp>().LerpBackgroundColorBack();       
    }

    void Attack() {
        // Instantiate(projectile, leftgun.transform.position, Quaternion.identity);
        // Instantiate(projectile, rightgun.transform.position, Quaternion.identity);  

        GameObject leftbullet = ObjectPooler.SharedInstance.GetPooledObject("bullet");

        if (leftbullet != null) {
            leftbullet.transform.position = leftgun.transform.position;
            leftbullet.transform.rotation = leftgun.transform.rotation;
            leftbullet.SetActive(true);
        }
        else if (leftbullet == null) {
            Debug.Log("Missfire!");
        }

        GameObject rightbullet = ObjectPooler.SharedInstance.GetPooledObject("bullet");

        if (rightbullet != null) {
            rightbullet.transform.position = rightgun.transform.position;
            rightbullet.transform.rotation = rightgun.transform.rotation;
            rightbullet.SetActive(true);
        }
        else if (rightbullet == null) {
            Debug.Log("Missfire!");
        }

        // GetComponent<AudioSource>().clip = bullet_sfx;
        // source.Play();      
    }

    IEnumerator FireShot() {
        canshoot = true;
        Attack();     
        shaker.SendMessage("TriggerShake");
        mainCamera.GetComponent<BackgroundColorLerp>().LerpBackgroundColor();
        yield return new WaitForSeconds(gunDelay);
        canshoot = false;
    }
}      
