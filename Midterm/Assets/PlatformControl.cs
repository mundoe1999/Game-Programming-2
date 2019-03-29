using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{

    private SpriteRenderer sr;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
      sr = GetComponent<SpriteRenderer>();
      sr.color = new Color(Random.Range(0f,0.8f), Random.Range(0f,0.8f), Random.Range(0f,0.8f), 1);
    }

    // Update is called once per frame
    void Update()
    {
      transform.localPosition = new Vector2(transform.localPosition.x - Time.deltaTime*speed, transform.localPosition.y);
      if(transform.localPosition.x < -12){
        //Prevents the player from being deleted along with gameObject
        if(transform.childCount > 0)
        {
          this.gameObject.transform.GetChild(0).transform.parent = null;
        }
        //Delete object
        Destroy(gameObject);
      }
    }
}
