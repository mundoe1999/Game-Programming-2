using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
  private bool dragging_item = false;
  private GameObject dragged_object;
  public List<GameObject> targetLocs;
  private Vector2 original_location;
  private GameObject attached_item = null;

    // Update is called once per frame
    void Update()
    {
      if(HasInput){
        DragOrPickup();
      } else{
        if(dragging_item){
          DropItem();
        }
      }

    }

    private void DragOrPickup(){
      var inputPosition = CurrentTouchPosition;
      if(dragging_item){
        dragged_object.transform.position = inputPosition;
      } else {
        LayerMask mask = LayerMask.GetMask("Draggable");
        RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f, mask);
        if(touches.Length > 0){
          //Pick up first item touched
          var hit = touches[0];
          if(hit.transform != null){
            dragging_item = true;
            dragged_object = hit.transform.gameObject;
            original_location = dragged_object.transform.parent.transform.position;
            //Places cables where it is supposed to belong
            if(dragged_object.tag == "R_Cable"){
              original_location.x += 0.5f;
            }
            else if(dragged_object.tag == "L_Cable"){
              original_location.x -= 0.5f;
            }
            else if(dragged_object.tag == "U_Cable"){
              original_location.y -= 0.5f;
            }
            else if(dragged_object.tag == "D_Cable"){
              original_location.y += 0.5f;
            }
          }
        }
      }
    }

    Vector2 CurrentTouchPosition{
      get {
        Vector2 inputPos;
        inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return inputPos;
      }
    }

    private bool HasInput{
      get {
        return Input.GetMouseButton(0); //is left mouse button
      }
    } //End HasInput

    private void DropItem(){

        dragging_item = false;
        var distance = Vector2.Distance(dragged_object.transform.position, targetLocs[0].transform.position);
        var target = targetLocs[0];

        //Debug.Log(distance);
        foreach(GameObject t in targetLocs){
          if(Vector2.Distance(dragged_object.transform.position, t.transform.position) < distance){
            target = t;
            distance = Vector2.Distance(dragged_object.transform.position, t.transform.position);
          }
        }

        SpriteRenderer test = target.gameObject.GetComponent<SpriteRenderer>();
        CableCharge cableAttached = dragged_object.GetComponent<CableCharge>();
        //Check if there are walls blocking the object
        if (Physics2D.Linecast(original_location, dragged_object.transform.position,LayerMask.GetMask("Wall")))
        {
          Debug.Log("blocked");
          if(cableAttached.attachedTo != null){
            if(cableAttached.attachedTo.tag == "Outlet"){
              OutletBox outlet_info;
              outlet_info = cableAttached.attachedTo.GetComponent<OutletBox>();

              if(dragged_object == outlet_info.Inputs.Contains(dragged_object)){
                outlet_info.Inputs.Remove(dragged_object);
                outlet_info.updateCharge();
              }
            }
          }

          changeAttached(cableAttached, null);
          cableAttached.attachedTo = null;
          dragged_object.transform.position = original_location;
          test.color = new Color (255, 255, 255);

        } //End Linecast
        else if(distance < 1 && target != dragged_object.transform.parent.gameObject){

          //Checking if it's a lightbulb
          if(target.tag == "Lightbulb"){
            Vector2 matched_position = target.transform.position;
            dragged_object.transform.position = matched_position;
            if(cableAttached.charge >= 1){
                test.color = new Color (255, 0, 0);
                //go to next level
                OutputBox output;
                output = target.GetComponent<OutputBox>();
                output.NextLevel();

            }


          }
          //Make sure that it is an outlet box
          else if(target.tag == "Outlet"){
            OutletBox outlet_info;
            outlet_info = target.GetComponent<OutletBox>();
            if(outlet_info.CurrentInput != outlet_info.MaxInput){
              Vector2 matched_position = target.transform.position;
              dragged_object.transform.position = matched_position;

              //Increase Input
              if(dragged_object != outlet_info.Inputs.Contains(dragged_object)){
                outlet_info.Inputs.Add(dragged_object);
                outlet_info.CurrentInput++;
                outlet_info.updateCharge();
                outlet_info.updateColor();
              }

            }
        }

        changeAttached(cableAttached,target);
        cableAttached.attachedTo = target;
        //attached_item = target;
      } //End Distance if
      //if distance > 1
        else {
          if(cableAttached.attachedTo != null){
            if(cableAttached.attachedTo.tag == "Outlet"){
              OutletBox outlet_info;
              outlet_info = cableAttached.attachedTo.GetComponent<OutletBox>();

              if(dragged_object == outlet_info.Inputs.Contains(dragged_object)){
                outlet_info.Inputs.Remove(dragged_object);
                outlet_info.updateCharge();
                outlet_info.updateColor();
              }
            }
          }

          changeAttached(cableAttached, null);
          cableAttached.attachedTo = null;
          dragged_object.transform.position = original_location;
          test.color = new Color (255, 255, 255);
        }

        attached_item = null;

    } //End dropItem

    //changeAttached function
    void changeAttached(CableCharge item, GameObject newAttached){
      GameObject item_attached = item.attachedTo;

      //Debugging information
      if(item_attached != null){
              Debug.Log("old: "+item_attached.tag);
      }
      if(newAttached != null){
              Debug.Log("new: "+newAttached.tag);
      }

      if(item_attached != null && item_attached != newAttached){
        SpriteRenderer test = item_attached.gameObject.GetComponent<SpriteRenderer>();
        if(item_attached.tag == "Outlet"){
          //Reduce current input by 1
          OutletBox outlet_info;
          outlet_info = item_attached.GetComponent<OutletBox>();
          Debug.Log("REDUCE");
          outlet_info.CurrentInput-= 1;
          if(dragged_object == outlet_info.Inputs.Contains(dragged_object)){
            outlet_info.Inputs.Remove(dragged_object);
            outlet_info.updateCharge();
          }
          //No inputs in the Outlet Box
          outlet_info.updateColor();
        }
        else if(item_attached.tag == "Lightbulb"){
          test.color = new Color (255, 255, 255);
        }
      }
      //Changed attached to new item
      item_attached = newAttached;
    } //End changeAttached
}
