using UnityEngine;
using System.Collections;
 
public class ObjectEmitter : MonoBehaviour {
     
    // public float speedMult = 1.0f;
    // public float rangeMult = 1.0f;

    // Use this for initialization
    public GameObject bullet;
    public GameObject turret;
    public float shootInterval = 1.0f;
    float basex = 0.0f;
    float shootTimeAc = 0.0f;
    // Update is called once per frame
    void Start() {
        basex = transform.position.x;
    }
    void Update () {
        Vector3 position = transform.position;
        //float interval = Mathf.Sin(Time.time * (speedMult / rangeMult)) * rangeMult;
        bool shoot = false;
        if(Time.deltaTime + shootTimeAc > shootInterval)
        {
            shootTimeAc = 0.0f;
            shoot = true;
        }
             
        else
            shootTimeAc += Time.deltaTime;
         
        //position.x = basex + interval;
         
        transform.position = position;
        if(shoot) {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(); 
            if (bullet != null) {
                bullet.transform.position = turret.transform.position;
                bullet.transform.rotation = turret.transform.rotation;
                bullet.SetActive(true);
            }
            else {
                Debug.Log("Missfire!");
            }
        }    
    }
}