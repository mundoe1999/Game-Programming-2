using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDrop : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      rb.velocity = new Vector2(0.0f, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collided){

      if(collided.gameObject.tag == "ground"){
        Debug.Log("Boop");
        Destroy(gameObject);
      }
    }
}
