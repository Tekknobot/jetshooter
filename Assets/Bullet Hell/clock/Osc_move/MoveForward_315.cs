using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward_315 : MonoBehaviour
{
    public float movementSpeed;
    Transform direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.Find("Osc_315").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.up * Time.deltaTime * movementSpeed;
    }

    void OnBecameInvisible() {
        if (gameObject.tag == "A315") {
            gameObject.SetActive(false);
        } else {
            Destroy(gameObject);
        }
    } 
}
