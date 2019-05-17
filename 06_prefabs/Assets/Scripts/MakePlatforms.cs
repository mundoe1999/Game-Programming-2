using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlatforms : MonoBehaviour
{

    float timer = 0;
    public float timeNewObject;
    public GameObject _object;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeNewObject){
          Instantiate(_object, new Vector2(Random.Range(-9,9),-4f),Quaternion.identity);
          _object.transform.localScale = new Vector2(Random.Range(2,9),0.5f);
          timer = 0;
        }
    }
}
