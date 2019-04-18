using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletBox : MonoBehaviour
{
  public int MaxInput;
  public int MaxOutput;
  public int CurrentInput = 0;
  public int box_charge = 0;
  public List<GameObject> Inputs;
  public List<GameObject> Outputs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateColor(){
      SpriteRenderer test = gameObject.GetComponent<SpriteRenderer>();
      if(box_charge == 2){
        Debug.Log("Yellow");
        test.color = new Color (255, 255, 0);
      } else if(box_charge == 1){
        test.color = new Color (255, 0, 0);
        Debug.Log("RED");
      } else if(box_charge < 1){
        Debug.Log("Gray");
        test.color = new Color (100, 100, 100);
      }
    }

    public void updateCharge(){
      float tempCharge = 0;
      foreach(GameObject input in Inputs){
        CableCharge cable = input.GetComponent<CableCharge>();
        tempCharge += cable.getCharge();
      }
      if(CurrentInput == 0){
        box_charge = 0;
      } else{
        box_charge = (int)Mathf.Ceil(tempCharge/CurrentInput)-1;
      }
      foreach(GameObject output in Outputs){
        CableCharge cable = output.GetComponent<CableCharge>();
        cable.charge = box_charge;
      }

    }

}
