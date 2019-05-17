using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
  public static gameManager control;

  //Character Information
  public string character_name;
  public int days_passed;

  //Score Values
  public int anxiety;
  public int max_anxiety;
  public float money;

  private void Awake(){
    if(control == null){
      control = this;
      DontDestroyOnLoad(gameObject);
    } else if(control != this){
      Destroy(gameObject);
    }
  } //End void Awake()


  public int getAnxiety(){
    return anxiety;
  }

    public float getMoney(){
    return money;
  }

  public void changeAnxietyBy(int amount){
    anxiety += amount;
    if(anxiety < 0){
      Debug.Log("hyuk");
      anxiety = 0;
      return;
    }

    if(anxiety > max_anxiety){
      Debug.Log("tes");
      anxiety = max_anxiety;
      return;
    }
  }

  public void changeMoneyyBy(float amount){
    money += amount;
  }
}
