using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject shot_prefab;
    public Transform shotLoc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space)){
        Instantiate(shot_prefab, shotLoc.position,shotLoc.rotation);
      }
    }
}
