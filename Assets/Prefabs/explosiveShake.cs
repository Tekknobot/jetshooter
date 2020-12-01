using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveShake : MonoBehaviour
{
    public GameObject maincamera;

    // Start is called before the first frame update
    void Awake()
    {
        maincamera = GameObject.FindGameObjectWithTag ("MainCamera");
        maincamera.SendMessage("TriggerShake", SendMessageOptions.RequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
