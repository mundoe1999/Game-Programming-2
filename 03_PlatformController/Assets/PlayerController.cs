using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveInput;
    private Rigidbody2D rb;

    private bool faceR = true;

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
    }

    // Update is called once per frame
    void Update()
    {
      if(isGrounded && Input.GetKeyDown(KeyCode.UpArrow)){
        rb.velocity = Vector2.up *jumpForce;
      }

    }
    //Used for physic updates since this is a constant
    private void FixedUpdate(){
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
      moveInput = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
      if(faceR && moveInput < 0){
        Flip();
      }
      if(!faceR && moveInput > 0){
        Flip();
      }
    }

    void Flip(){
      faceR = !faceR;
      Vector3 scaler = transform.localScale;
      scaler.x *= -1;
      transform.localScale = scaler;
    }
}
