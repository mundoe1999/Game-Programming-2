using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoTrigger : MonoBehaviour
{
  private bool dum = false;
  void Update(){
    if(!dum){
        //Only have to call it for a single frame
         gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
         Destroy(GetComponent<autoTrigger>());
    }

  }
}
