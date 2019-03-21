using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    private Vector3 savedPos;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position+ new Vector3(3f,-0.2f,4.0f);
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position + offset;

    }

    void FixedUpdate()
    {

    }
}
