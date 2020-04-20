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
        if (Time.timeScale != 0)
        {
            float y = Input.GetAxis("Mouse X") * turnSpeed;
   
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);

            transform.position = target.transform.position - (transform.forward * targetDistance);
            transform.position += new Vector3(0, heightOffset, 0);





        }


    }
}
