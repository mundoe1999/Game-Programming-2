using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public string sceneLevel;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision player){
      if(player.gameObject.tag == "Player"){
        SceneManager.LoadScene(sceneLevel);
      }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
