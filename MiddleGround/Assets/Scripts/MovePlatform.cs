using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    float timer = 0;
    bool movingBack = false;
    public float distanceBeforeTurn;
    public float speed;
    float originalX;
    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.localPosition.x;
        Debug.Log("OriginalX" + originalX);
    }

    // Update is called once per frame
    void Update()
    {
        if(!movingBack){
          if(transform.localPosition.x > originalX+distanceBeforeTurn){
            movingBack = !movingBack;
          }
          transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime*speed,transform.localPosition.y, transform.localPosition.z);
        } else{
          if(transform.localPosition.x < originalX){
            movingBack = !movingBack;
          }
          transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime*speed,transform.localPosition.y, transform.localPosition.z);
        }
    }
}
