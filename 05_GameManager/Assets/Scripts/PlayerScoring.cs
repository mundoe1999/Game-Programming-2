using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScoring : MonoBehaviour
{
  public Text scoreText;
    // Update is called once per frame
    private void Awake(){
      scoreText.text = "Score: " + GameControl.control.score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SquareUp"){
          GameControl.control.score++;
          scoreText.text = "Score: " + GameControl.control.score.ToString();
        }
        if(collision.gameObject.tag == "SquareDown"){
          GameControl.control.score--;
          scoreText.text = "Score: " + GameControl.control.score.ToString();
        }
    }
}
