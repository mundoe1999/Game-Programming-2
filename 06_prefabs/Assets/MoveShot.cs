using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShot : MonoBehaviour
{
    //public GameObject SpawnObject;
    public float speed;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.up*speed*Time.deltaTime);
      timer += Time.deltaTime;
      if(timer > 1){
        Destroy(this.gameObject);
      }
    }
}
