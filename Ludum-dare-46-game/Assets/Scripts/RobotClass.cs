using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class RobotClass : MonoBehaviour
{

    public float battery_left = 100;
    public float battery_max = 100;

    float decharge_rate = 4.0f;
    float charge_rate = 15.0f;
    public bool has_item = false;
    bool is_charging = false;

    public int kitsLeft;

    public float turnSpeed = 3.0f;
    public float moveSpeed = 18.0f;

    public GameObject allBeacons;
    public GameObject allKits;


    void Update()
    {
        if (Time.timeScale != 0)
        {
            MouseAiming();

            if (!is_charging && battery_left > 0.0f)
                battery_left -= decharge_rate * Time.deltaTime;

             kitsLeft = allKits.transform.childCount;
        }
    }

    private void FixedUpdate()
    {
        KeyboardMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MedKit" && !has_item)
        {

            Destroy(other.gameObject);
            has_item = true;
            int childCount = allBeacons.transform.childCount;
            allBeacons.transform.GetChild(Random.Range(0, childCount - 1)).gameObject.SetActive(true);

            //Add text...
        }
        if(other.gameObject.tag == "DeliveryBeacon" && has_item)
        {
            Destroy(other.gameObject);
            has_item = false;
            //Add text...
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ChargingStation" && battery_left < battery_max)
        {
            is_charging = true;
            battery_left += charge_rate * Time.deltaTime;
        }
        is_charging = false;
    }

    void MouseAiming()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
    }

    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        dir.z = Input.GetAxis("Vertical");

        if(battery_left > 0.0f)
            transform.Translate(dir * moveSpeed * Time.deltaTime);
            
    }

    void GoToMainMenu()
    {

    }
}
