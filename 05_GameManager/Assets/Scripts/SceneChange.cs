using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
  public int sceneToLoad;
  private void OnGUI(){
    if(GUI.Button(new Rect(Screen.width/2, Screen.height - 50, 100, 40), "Next")){
      SceneManager.LoadScene(sceneToLoad);
    }
  }
}
