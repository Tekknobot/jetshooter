using UnityEngine;
using System.Collections;
 
public class SmoothFallback : MonoBehaviour {
     
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
 
    // Update is called once per frame
    void Update () 
    {
        if (target)
        {
            Vector3 point = transform.position;
            Vector3 delta = target.position - transform.position;
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}