using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLaser : MonoBehaviour
{
    public GameObject player;
    public float Radius;
    public GameObject laser;
    public float laserDuration = 10;
    public float timeRemaining = 5;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    public AudioClip warning_sfx;
    private AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
 
        if (dist < Radius)
        {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                if (Time.time > nextActionTime ) {
                    nextActionTime += period;
                    GetComponent<AudioSource>().clip = warning_sfx;
                    source.Play();
                }
            }    
            else {
                StartCoroutine(TriggerEnemyLaser());
                source.Stop();
            }      
        } 
        else {
            timeRemaining = 5;
            laser.SetActive(false);
            source.Stop();
        }   
    }

    IEnumerator TriggerEnemyLaser() {
        laser.SetActive(true);
        yield return new WaitForSeconds(laserDuration);
        laser.SetActive(false);
        timeRemaining = 5;
    }

    IEnumerator PlayWarning() {
        GetComponent<AudioSource>().clip = warning_sfx;
        source.Play();
        yield return new WaitForSeconds(2);
    }    
}
