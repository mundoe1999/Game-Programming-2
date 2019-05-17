using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCircles : MonoBehaviour
{

    public GameObject circle_prefab;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
      for(int i = 0; i < 20; i++){
        GameObject _object;
        _object = Instantiate(circle_prefab, new Vector2(Random.Range(-10,10), Random.Range(0,3.6f)), Quaternion.identity);
        float randomScale = Random.Range(0.2f,3);
        _object.transform.localScale = new Vector2(randomScale, randomScale);
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Fire1")){
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        var targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(circle_prefab, targetPos, Quaternion.identity);
      }
    }
}
