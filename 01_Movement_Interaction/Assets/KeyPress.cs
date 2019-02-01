using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPress : MonoBehaviour
{

    public float MoveSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
      MoveSpeed = 5;
      rotateSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.DownArrow)){
//        transform.Translate(new Vector3 (0,-1,0));
        transform.Translate(Vector3.forward*MoveSpeed*Time.deltaTime);
      }
      if(Input.GetKeyDown(KeyCode.UpArrow)){
//        transform.Translate(new Vector3 (0,1,0));
        transform.Translate(Vector3.back*MoveSpeed*Time.deltaTime);
      }
      if(Input.GetKey(KeyCode.LeftArrow)){
        transform.Rotate(new Vector3(0,rotateSpeed,0));
      }
      if(Input.GetKey(KeyCode.RightArrow)){
        transform.Rotate(new Vector3(0,-rotateSpeed,0));
      }
      //transform.Translate(new Vector3(0,0,MoveSpeed*Time.deltaTime));
    }

    void OnMouseDown(){
      Debug.Log("clicked!");
      transform.Translate(new Vector3(0,1,0));
    }
}
