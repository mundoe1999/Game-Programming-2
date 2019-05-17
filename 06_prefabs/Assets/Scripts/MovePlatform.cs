﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    public float speed;

    void Start(){

    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y+speed*Time.deltaTime);
        if(transform.localPosition.y > 6.2f){
          Destroy(this.gameObject);
        }
    }
}
