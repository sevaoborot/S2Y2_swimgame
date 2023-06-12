using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIendis : MonoBehaviour
{
     public GameObject canvas;


     private void OnTriggerEnter(Collider other)
   {
     if(other.CompareTag("Player"))
     {
         canvas.SetActive(true);
         
     }
     else
     {

         canvas.SetActive(false);
     }
   }
}
