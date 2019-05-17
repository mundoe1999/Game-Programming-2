using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class work_countdown : MonoBehaviour
{
  public float counter =60f;
  public Text countText;
  public float counterDecreaser;
  public string sceneName;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(counter > 0){
          counter -= counterDecreaser;
          countText.text = counter.ToString("F2");
        } else{
          SceneManager.LoadScene(sceneName);
        }
    }
}
