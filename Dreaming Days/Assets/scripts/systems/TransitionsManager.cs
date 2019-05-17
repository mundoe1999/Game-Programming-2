using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionsManager : MonoBehaviour
{
  public void LoadingScene(string sceneName){
     SceneManager.LoadScene(sceneName);
  }
}

