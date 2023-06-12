using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpwaning : MonoBehaviour
{

    

        public GameObject spawnObject;
    // public Vector3 spawnPoint;
    public Vector3 spawnPoint;
     public int maxX = 10;
     public int timeTilNextSpawn = 5;
     int x = 0;
     float timer = 0;
    private GameObject newinstance;
    
 
     void Start()
     {
         timer = 0;
         ;
     }
 
     private void Update()
     {
         timer += Time.deltaTime;
         Spawn();
     }
 
     void Spawn()
     {
         if (timer >= timeTilNextSpawn)
         {
           ;
             
             newinstance = Instantiate(spawnObject, spawnPoint, Quaternion.identity);
             timer = 0;
            Destroy(newinstance, 12);
         }
     }
}




