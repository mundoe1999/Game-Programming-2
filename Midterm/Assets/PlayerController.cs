using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private float moveInput;
  private Rigidbody2D rb;
  private SpriteRenderer sr;

  private bool isGrounded;
  public Transform groundCheck;
  public LayerMask  whatIsGround;
  public float checkRadius;

  public float speed;
  public float jumpForce;



    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
      if(isGrounded && Input.GetKeyDown(KeyCode.UpArrow)){
        rb.velocity = Vector2.up *jumpForce;
      }
    }
    void FixedUpdate()
    {
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
      moveInput = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);

    }
    void OnCollisionEnter2D(Collision2D test){
      SpriteRenderer testsr = test.gameObject.GetComponent<SpriteRenderer>();
      Color newColor = testsr.color;
      //Debug.Log(newColor);
      if(test.gameObject.tag == "Platform"){
        Debug.Log("touch");
        this.transform.parent = test.transform;
        sr.color = new Color (newColor.r, newColor.g, newColor.b);
        //Debug.Log(newColor.r);
      }
    }
    void OnCollisionExit2D(Collision2D test){
      this.transform.parent = null;
    }
}
