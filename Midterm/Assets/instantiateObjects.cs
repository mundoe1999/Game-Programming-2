using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateObjects : MonoBehaviour
{
  float timer = 0;
  public float timeNewObject;
  public GameObject _object;
  public float ObjectSpeed;


    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;
      if(timer > timeNewObject){
        Instantiate(_object, new Vector2(9,Random.Range(-5f, 5f)),Quaternion.identity);
        timer = 0;
      }
    }
}
