using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
 public GameObject gameManipulator;
 public Slider anxietyBar;
 public Text moneyText;

 private gameManager gm;
 private float money_written;

 void Start(){
  gm = gameManipulator.GetComponent<gameManager>();
  money_written = gm.getMoney();
  moneyText.text = "$"+money_written.ToString("F2");
  anxietyBar.value = gm.getAnxiety();
 }

 /*
  Other classes should be able to call these methods.
  Functions in this script are essentially wrapper functions
  in order to prevent a bunch of uneccesary issues
  involving linking with gameManager object
 */

 public void changeAnxietyBy(int newAnxiety){
  gm.changeAnxietyBy(newAnxiety);
  StartCoroutine(changeAnxietyBar());
 }

  public void changeMoneyBy(float newMoney){
  gm.changeMoneyyBy(newMoney);
  StartCoroutine(changeMoney());
 }

 public void increaseDay(){
  gm.days_passed++;
 }

 IEnumerator changeAnxietyBar(){
  int curr_anxiety = gm.getAnxiety();

  while(anxietyBar.value < curr_anxiety){
    anxietyBar.value += 0.3f;
    yield return null;
  }
  //Prevent the bar from going over
  anxietyBar.value = curr_anxiety;

 }

  IEnumerator changeMoney(){
  float curr_money= gm.getMoney();

  while(money_written < curr_money){
    money_written += 0.07f;
    moneyText.text = "$"+money_written.ToString("F2");
    yield return null;
  }
  //Prevent the bar from going over
  money_written = curr_money;
  moneyText.text = "$"+money_written.ToString("F2");

 }
}


