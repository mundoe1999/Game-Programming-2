using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
  public Text scoreText;
  public int score = 0;
  public Slider scoreSlider;

  private void Start(){
    scoreText.text += " " + score.ToString();
    scoreSlider.value = score;
  }

  private void OnCollisionEnter2D(Collision2D otherObject){
    if(otherObject.gameObject.tag == "Coin"){
      Destroy(otherObject.gameObject);
      score++;
      if(score == 5){
        scoreText.text = "WINNER or not?";
      }else{
        scoreText.text = "Score: " + score.ToString();
      }
      scoreSlider.value = score;
      Debug.Log(score);
    }
  }
}
