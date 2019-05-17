using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemControl : MonoBehaviour
{
  public float timer = 0;
  public float timeNewObject;
  public GameObject _object;


    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;
      if(timer > timeNewObject){
        Instantiate(_object, new Vector2(Random.Range(-5f,5f),7f),Quaternion.identity);
        timer = 0;
      }
    }
}
