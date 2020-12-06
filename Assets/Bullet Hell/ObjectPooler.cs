using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledObjects;
    public List<GameObject> bulletpooledObjects;

    public GameObject objectToPool;
    public GameObject objectToPool_1;
    public GameObject objectToPool_2;
    public GameObject objectToPool_3;
    public GameObject objectToPool_4;
    public GameObject objectToPool_5;
    public GameObject objectToPool_6;
    public GameObject objectToPool_7;
    public GameObject objectToPool_8;

    public GameObject projectileToPool;

    public int amountToPool;
    
    void Awake() {
        SharedInstance = this;
    }

    void Start() {
        pooledObjects = new List<GameObject>();
        bulletpooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);

            GameObject obj1 = (GameObject)Instantiate(objectToPool_1);
            obj1.SetActive(false); 
            pooledObjects.Add(obj1);

            GameObject obj2 = (GameObject)Instantiate(objectToPool_2);
            obj2.SetActive(false); 
            pooledObjects.Add(obj2);

            GameObject obj3 = (GameObject)Instantiate(objectToPool_3);
            obj3.SetActive(false); 
            pooledObjects.Add(obj3);

            GameObject obj4 = (GameObject)Instantiate(objectToPool_4);
            obj4.SetActive(false); 
            pooledObjects.Add(obj4);

            GameObject obj5 = (GameObject)Instantiate(objectToPool_5);
            obj5.SetActive(false); 
            pooledObjects.Add(obj5);

            GameObject obj6 = (GameObject)Instantiate(objectToPool_6);
            obj6.SetActive(false); 
            pooledObjects.Add(obj6);

            GameObject obj7 = (GameObject)Instantiate(objectToPool_7);
            obj7.SetActive(false); 
            pooledObjects.Add(obj7);

            GameObject obj8 = (GameObject)Instantiate(objectToPool_8);
            obj8.SetActive(false); 
            pooledObjects.Add(obj8); 

            GameObject projectile = (GameObject)Instantiate(projectileToPool);
            projectile.SetActive(false); 
            bulletpooledObjects.Add(projectile);                        
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject() {
    //1
    for (int i = 0; i < pooledObjects.Count; i++) {
    //2
        if (!pooledObjects[i].activeInHierarchy) {
        return pooledObjects[i];
        }
    }
    //3   
    return null;
    }    

    public GameObject BulletPooledObject() {
    //1
    for (int i = 0; i < bulletpooledObjects.Count; i++) {
    //2
        if (!bulletpooledObjects[i].activeInHierarchy) {
        return bulletpooledObjects[i];
        }
    }
    //3   
    return null;
    }     
}
