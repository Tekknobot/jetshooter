using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class MoveBackground : MonoBehaviour {
 
    public float speed = 2f;
    public float yDirection = -1; //move from right to left
   
    // Use this for initialization
    void Start () {
    
    }
     
    // Update is called once per frame
    void Update () {
        //move the root BG from right to left
        transform.Translate(new Vector3(0, speed * yDirection * Time.deltaTime, 0));
        if (transform.position.y <= -10) {
            transform.position = new Vector3(0,0,0);
        }
    }   
}