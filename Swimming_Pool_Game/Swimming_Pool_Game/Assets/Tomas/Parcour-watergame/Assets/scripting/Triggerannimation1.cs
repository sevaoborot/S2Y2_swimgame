using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerannimation : MonoBehaviour
{
   [SerializeField] private Animator myAn;

   [SerializeField] private string Playanimation = "PlayAnimation";

   private void OnTriggerEnter(Collider other)
   {
     if(other.CompareTag("Player"))
     {
         myAn.Play(Playanimation, 0, 0.0f);
         gameObject.GetComponent<BoxCollider>().enabled = false;
     }
   }
}
