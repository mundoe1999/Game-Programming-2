using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    public float speed;
    public float cash;
    public scoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collided){

      if(collided.gameObject.tag == "item"){
        sm.changeMoneyBy(11.73f);
        sm.changeAnxietyBy(2);

        Destroy(collided.gameObject);
      }
    }
}
