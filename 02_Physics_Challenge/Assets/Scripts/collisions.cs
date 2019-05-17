using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour
{
  private Rigidbody rb;

  void Start(){
    rb = GetComponent<Rigidbody>();
  }

  void OnCollisionEnter(Collision other){
    Debug.Log("Collision detected!");
    if(other.gameObject.tag == "Sphere"){
      GetComponent<Renderer>().material.color = Color.red;
    } else {
      //Something else
      GetComponent<Renderer>().material.color = Color.yellow;
    }

    if(other.gameObject.tag == "floor"){
        rb.AddForce(new Vector3(0,200,0));
    }

  }
  void OnCollisionStay(Collision other){
    Debug.Log("I told you to get off me!");
  }
  void OnCollisionExit(Collision other){
    GetComponent<Renderer>().material.color = Color.blue;
  }
}
