using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
  //Script that keeps track of stuff
  public static GameControl control;
  public PlayerController player;
  public Slider healthSlider;

  public int health = 3;
  private int count = 0;
  private void Awake(){
    if(control == null){
      control = this;
      DontDestroyOnLoad(gameObject);
    } else if(control != this){
      Destroy(gameObject);
    }
  } //End void Awake()

  void FixedUpdate(){
    if(health == 0){
      SceneManager.LoadScene("GameOver");
      Destroy(gameObject);
    }

    healthSlider.value = health;
    if(player.transform.localPosition.y <= -5){
      player.moveToLastLocation();
      health--;
    }
  }
}
