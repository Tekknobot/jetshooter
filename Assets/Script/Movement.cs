using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            //movement
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 tmpDir = mousePosition - transform.position;
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * 1f / tmpDir.magnitude * Time.deltaTime);
        } 
    }
}
