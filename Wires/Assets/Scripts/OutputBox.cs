using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OutputBox : MonoBehaviour
{
  public int max_cables;
  private int current_cables = 0;

  public void NextLevel(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

    // Update is called once per frame
    void Update()
    {

    }
}
