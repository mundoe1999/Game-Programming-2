using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
  private bool dragging_item = false;
  private GameObject dragged_object;
  public List<Transform> targetLocs;

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

        var distance = Vector2.Distance(dragged_object.transform.position, targetLocs[0].position);
        var target = targetLocs[0];
        Debug.Log(distance);
        foreach(Transform t in targetLocs){
          if(Vector2.Distance(dragged_object.transform.position, t.position) < distance){
            target = t;
            distance = Vector2.Distance(dragged_object.transform.position, t.position);
          }
        }
        if(distance < 1){
          Vector2 matched_position = target.position;
          dragged_object.transform.position = matched_position;
        }


    }
}
