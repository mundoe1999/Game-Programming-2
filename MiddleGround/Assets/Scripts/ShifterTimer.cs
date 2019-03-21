using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShifterTimer : MonoBehaviour
{

    public int count = 60;
    public int TimerCooldown = 60;
    public Slider shiftSlider;
    public GameObject player;
    public GameObject camera;
    public CameraController camControl;
    private bool shiftReady = true;
    public PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(!shiftReady){
        if(count == TimerCooldown){
          shiftReady = true;
        } else{
          count++;
        }
      } else{
        if(Input.GetKey(KeyCode.LeftShift)){
          Flip();
        }
      }

      shiftSlider.value = count;
    }

    void Flip()
    {
        shiftReady = false;
        count = 0;
        Vector3 scaler = camera.transform.localPosition;
        Vector3 playerScaler = player.transform.position;
        scaler.z = (scaler.z-5)*-1;
        camera.transform.Rotate(0, 180, 0, Space.Self);
        camControl.offset.z *= -1;
        playerScript.isFlipped *= -1;
        playerScaler.z *= -1;
        playerScaler.z += 5.0f;
        camera.transform.localPosition = scaler;
        player.transform.localPosition = playerScaler;
    }
}
