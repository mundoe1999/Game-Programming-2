using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public int initialSelect = 0;
    public Text Startgame;
    public Text Quitgame;

    // Start is called before the first frame update
    void Start()
    {
      Startgame.color = new Color (255,0,0,1);
      Quitgame.color = new Color (0,0,0,1);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)){
        initialSelect= (initialSelect+1)%2;
        if(initialSelect == 1){
          Startgame.color = new Color (0,0,0,1);
          Quitgame.color = new Color (255,0,0,1);
        } else{
          Startgame.color = new Color (255,0,0,1);
          Quitgame.color = new Color (0,0,0,1);
        }
      }

      if(initialSelect == 0 && Input.GetKey(KeyCode.Space)){
        SceneManager.LoadScene("level01");

      }
      if(initialSelect == 1 && Input.GetKey(KeyCode.Space)){
        Application.Quit();
      }
    }
}
