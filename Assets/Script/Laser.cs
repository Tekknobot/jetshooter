using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laserParticles;
    private LineRenderer _lineRenderer;
    public HealthBar healthBar;
    playerTarget player;
    private string playerTag = "player";
    public int laserDamage;

    private RaycastHit2D hit;

    // Use this for initialization
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        player = GameObject.Find("Player").GetComponent<playerTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        hit = Physics2D.Raycast(transform.position, transform.up);
        
        if (hit.collider.tag == playerTag)
        {
            _lineRenderer.SetPosition(1, new Vector3(hit.point.x, hit.point.y, transform.position.z));
            Instantiate(laserParticles, hit.point, Quaternion.identity);

            player.currentHealth -= laserDamage;
            healthBar.SetHealth(player.currentHealth);
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.up * 500);
        }
    }  
}
