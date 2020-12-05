using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOscillator : MonoBehaviour
{
    public float speed;
    public float floatz;

    public GameObject[] emitters;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartClock());
        emitters = GameObject.FindGameObjectsWithTag("Hell_Emitter");
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(0,0,floatz) * Time.deltaTime * speed);
    }

    IEnumerator StartClock() {
        floatz = 10;
        foreach (GameObject emitter in emitters) {
            emitter.GetComponent<ObjectEmitter>().shootInterval = 0.5f;
        }
        yield return new WaitForSeconds(10);
        StartCoroutine(StartClockWise());
    }

    IEnumerator StartClockWise() {
        floatz = -10;
        foreach (GameObject emitter in emitters) {
            emitter.GetComponent<ObjectEmitter>().shootInterval = 0.3f;
        }
        yield return new WaitForSeconds(10);
        StartCoroutine(StartClock());
    }
}
