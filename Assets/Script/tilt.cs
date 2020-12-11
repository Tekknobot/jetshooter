using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour
{
    public float maxRotation = 45f;
    public float roationSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * roationSpeed), 0f);
    }
}
