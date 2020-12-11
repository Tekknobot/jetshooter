using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public GameObject laser;

    Transform leader;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        leader = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = leader.transform.position - transform.position;
    }
}
