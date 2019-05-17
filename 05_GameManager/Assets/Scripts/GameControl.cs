using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
  //Script that keeps track of stuff
  public static GameControl control;
  public int score;

  private void Awake(){
    if(control == null){
      control = this;
      DontDestroyOnLoad(gameObject);
    } else if(control != this){
      Destroy(gameObject);
    }
  } //End void Awake()


}
