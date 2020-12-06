using UnityEngine;
using System.Collections;
 
public class ObjectEmitter: MonoBehaviour {
     
    // public float speedMult = 1.0f;
    // public float rangeMult = 1.0f;

    // Use this for initialization
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
            GameObject bullet_miniA0 = ObjectPooler.SharedInstance.GetPooledObject("A0"); 
            GameObject bullet_miniA45 = ObjectPooler.SharedInstance.GetPooledObject("A45");
            GameObject bullet_miniA90 = ObjectPooler.SharedInstance.GetPooledObject("A90");
            GameObject bullet_miniA135 = ObjectPooler.SharedInstance.GetPooledObject("A135");
            GameObject bullet_miniA180 = ObjectPooler.SharedInstance.GetPooledObject("A180");
            GameObject bullet_miniA225 = ObjectPooler.SharedInstance.GetPooledObject("A225");
            GameObject bullet_miniA270 = ObjectPooler.SharedInstance.GetPooledObject("A270");
            GameObject bullet_miniA360 = ObjectPooler.SharedInstance.GetPooledObject("A360");

            if (bullet_miniA0 != null && bullet_miniA45 != null && bullet_miniA90 != null && bullet_miniA135 != null && 
            bullet_miniA180 != null && bullet_miniA225 != null && bullet_miniA270 != null && bullet_miniA360 != null) {

                bullet_miniA0.transform.position = turret.transform.position;
                bullet_miniA0.transform.rotation = turret.transform.rotation;
                bullet_miniA0.SetActive(true);

                bullet_miniA45.transform.position = turret.transform.position;
                bullet_miniA45.transform.rotation = turret.transform.rotation;
                bullet_miniA45.SetActive(true);

                bullet_miniA90.transform.position = turret.transform.position;
                bullet_miniA90.transform.rotation = turret.transform.rotation;
                bullet_miniA90.SetActive(true);

                bullet_miniA135.transform.position = turret.transform.position;
                bullet_miniA135.transform.rotation = turret.transform.rotation;
                bullet_miniA135.SetActive(true);

                bullet_miniA180.transform.position = turret.transform.position;
                bullet_miniA180.transform.rotation = turret.transform.rotation;
                bullet_miniA180.SetActive(true);

                bullet_miniA225.transform.position = turret.transform.position;
                bullet_miniA225.transform.rotation = turret.transform.rotation;
                bullet_miniA225.SetActive(true);

                bullet_miniA270.transform.position = turret.transform.position;
                bullet_miniA270.transform.rotation = turret.transform.rotation;
                bullet_miniA270.SetActive(true);

                bullet_miniA360.transform.position = turret.transform.position;
                bullet_miniA360.transform.rotation = turret.transform.rotation;
                bullet_miniA360.SetActive(true);                                                                                                              
            } 
        }    
    }
}