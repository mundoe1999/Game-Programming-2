using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private float moveInput;
    private Rigidbody rb;

    public float speed;
    public float jumpForce;

    public int isFlipped = 1;
    private int count;
    private bool faceR = true;
    private Vector3 lastLocation;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask  whatIsGround;
    public float checkRadius;

    public double accelerateSpeed = 0.05;
    public float maxSpeed;
    private float speedYeet = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
      if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
        Jump();
      }
    }

    void OnCollisionEnter(Collision test){
      if(test.gameObject.tag == "Platform"){
        Debug.Log("touch");
        this.transform.parent = test.transform;
      }
      //In case player falls to death
      else if(test.gameObject.tag == "SolidGround" && isGrounded){
        lastLocation = transform.localPosition;
      }
    }

    void OnCollisionExit(Collision test){
      this.transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);
        //Debug.Log(isGrounded);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveInput*isFlipped * speed, rb.velocity.y,0.0f);



        if(faceR && moveInput*isFlipped < 0)
        {
            Flip();
        }
        if(!faceR && moveInput*isFlipped > 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        faceR = !faceR;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }
    void Jump(){
      rb.velocity = Vector3.up *jumpForce;
    }

    public void moveToLastLocation(){
      transform.localPosition = lastLocation;
    }
}
