using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCharge : MonoBehaviour
{
    public int charge;
    public GameObject attachedTo = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getCharge(){
      return charge;
    }

}
