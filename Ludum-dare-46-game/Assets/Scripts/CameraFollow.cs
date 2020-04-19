using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	
public float turnSpeed = 4.0f;

    public GameObject target;
    private float targetDistance;


    public float heightOffset = 0.0f;
    private float rotX;
    

    void Start()
    {
         targetDistance = Vector3.Distance(transform.position, target.transform.position);
    }

    void Update()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        // move the camera position
        transform.position = target.transform.position - (transform.forward * targetDistance);
        transform.position += new Vector3(0,heightOffset,0);

       


    }
}
