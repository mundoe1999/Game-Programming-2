using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
      winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate(){

      if(Input.GetKey(KeyCode.Space) && GetComponent<Transform>().position.y == 0.5){
        rb.AddForce(new Vector3(0,200,0));
      }

      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

      rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other){
      if(other.gameObject.CompareTag("Pick Up")){
        other.gameObject.SetActive(false);
        count++;
        SetCountText();
      }
    }

    void SetCountText(){
      countText.text = "Count: " + count.ToString();
      if (count >= 14){
        winText.text = "You win!";
      }
    }
}
